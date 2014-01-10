using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Collections;
using System.Xml;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace GenerateDependentViews
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class generateDependentViews : IExternalCommand
    {
        #region IExternalCommand Members Implementation

        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData,
            ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Transaction newTran = null;
            Transaction secondTran = null;

            int i = 0;

            try
            {
                if (null == commandData)
                {
                    throw new ArgumentNullException("commandData");
                }

                Document doc = commandData.Application.ActiveUIDocument.Document;
                genDepViewsData view = new genDepViewsData(doc);

                newTran = new Transaction(doc);
                newTran.Start("Generate Dependent Views");   //What is this line for?

                genDepViewsForm dlg = new genDepViewsForm(view);
                

                if (dlg.ShowDialog() == DialogResult.OK) //when the OK button in the form is pressed
                {
                    view.DuplicatePlan(doc);// calls the DuplicatePlan Method in the genDepViewsData Class to Duplicate selected Floor Plan after selecting OK
                }
                                
                newTran.Commit();

                secondTran = new Transaction(doc);
                secondTran.Start("Refresh Dependent Views");
                
                refreshDepViewsData Data = new refreshDepViewsData(doc);
                for (i = 0; i < 6; i++)
                {
                    Data.CleanGroups(Data.viewstring[i], Data.grpstring[i]);
                }

                Autodesk.Revit.UI.TaskDialog.Show("Refresh Dependent Views", "All Dependent Views Cleaned.");
                secondTran.Commit();

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                if ((newTran != null) && newTran.HasStarted() && !newTran.HasEnded())
                    newTran.RollBack();
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
        #endregion IExternalCommand Members Implementation
    }

    /// <summary>
    /// Generating a new duplicated as dependent view, based on a selection of floor plans and selection of dependent view types.
    /// </summary>
    public class genDepViewsData
    {
        private TreeNode m_allViewsNames = new TreeNode("Plan Views");
        private ViewSet m_allViews = new ViewSet();
        private ViewSet m_selectedViews = new ViewSet();
        private List<string> m_selectedchklistbox = new List<string> ();

        /// <summary>
        /// Tree node store all plan views' names.
        /// </summary>
        public TreeNode AllViewsNames
        {
            get
            {
                return m_allViewsNames;
            }
        }

        public genDepViewsData(Document doc)
        {
          GetPlanViews(doc);
        }

        /// <summary>
        /// Finds all the plan views in the active document.
        /// </summary>
        /// <param name="doc">the active document</param>
        private void GetPlanViews(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            FilteredElementIterator itor = collector.OfClass(typeof(Autodesk.Revit.DB.View)).GetElementIterator();
            itor.Reset();
            while (itor.MoveNext())
            {
                Autodesk.Revit.DB.View view = itor.Current as Autodesk.Revit.DB.View;
                // skip view templates because they're invisible in project browser
                if (null == view || view.IsTemplate)
                {
                    continue;
                }
                else
                {
                    ElementType objType = doc.GetElement(view.GetTypeId()) as ElementType;
                    if (null == objType || objType.Name.Equals("Schedule") || objType.Name.Equals("Drawing Sheet")) //if obj is null, schedule or dwg, continue loop
                    {
                        continue;
                    }
                    else if (objType.Name.Equals("Floor Plan"))
                    {
                        m_allViews.Insert(view);
                        AssortViews(view.Name, objType.Name);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Assort all views for tree view displaying.
        /// </summary>
        /// <param name="view">The view assorting</param>
        /// <param name="type">The type of view</param>
        private void AssortViews(string view, string type)
        {
            foreach (TreeNode t in AllViewsNames.Nodes)
            {
                if (t.Tag.Equals(type))
                {
                    t.Nodes.Add(new TreeNode(view));
                    return;
                }
            }

            TreeNode categoryNode = new TreeNode(type);
            categoryNode.Tag = type;
            categoryNode.Text = type + "s";

            categoryNode.Nodes.Add(new TreeNode(view));
            AllViewsNames.Nodes.Add(categoryNode);
            AllViewsNames.Nodes.Add(view);
        }

        /// <summary>
        /// Retrieve the checked views from treeView
        /// </summary>
        public void SelectViews()
        {
            ArrayList names = new ArrayList();
            
            foreach (TreeNode t in AllViewsNames.Nodes)
            {
                foreach (TreeNode n in t.Nodes)
                {
                    if (n.Checked && 0 == n.Nodes.Count)
                    {
                        names.Add(n.Text);
                    }
                }
            }

            foreach (Autodesk.Revit.DB.View v in m_allViews)
            {
                foreach (string s in names)
                {
                    if (s.Equals(v.Name))
                    {
                        m_selectedViews.Insert(v);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// retrieve checked items from Checked List Box
        /// </summary>
        public void getCheckedItemsCheckedListBox(CheckedListBox chklistbox)            //retrieving the checked items in the checkedlistbox as a string 
        {
            foreach (object item in chklistbox.CheckedItems)
            {
                m_selectedchklistbox.Add(item.ToString());                              //and add the checked items into a list of strings
            }
        }

        /// <summary>
        /// activate duplicate as dependent, and show dialog on result
        /// </summary>
        public void DuplicatePlan(Document doc)
        {
            foreach (string s in m_selectedchklistbox)
            {
                DuplicateAsDependentView(doc, m_selectedViews, s);      //call the duplicate as dependent view method
            }

            List<string> msg_selectview = new List<string>();

            foreach (Autodesk.Revit.DB.View v in m_selectedViews)
            {
                msg_selectview.Add(v.Name);
            }

            var selectviewsmsg = string.Join("\n", msg_selectview);            //combine all selected views as a single string
            var dependentviewmsg = string.Join("\n", m_selectedchklistbox);     //combine all selected dependent views as a single string

            //show dialog to confirm the created dependent views
            Autodesk.Revit.UI.TaskDialog.Show("Duplicate as Dependent Complete", "The following Dependent Views :\n\n" + dependentviewmsg + "\n\n" + "Has been created for the following Floor Plans :\n\n" + selectviewsmsg);
        }

        /// <summary>
        /// method to duplicate as dependent and rename dependent views
        /// </summary>
        public void DuplicateAsDependentView(Document doc, ViewSet views, string chkbox) //this is to create Duplicates of the Plan views and Rename them
        {
            if (0 == views.Size)
            {
                throw new InvalidOperationException("No view is selected, duplicate view as dependent will be cancelled.");     //check that views are selected
            }
            else
            {
                foreach (Autodesk.Revit.DB.View v in views)
                {
                    ElementId dupViewId = v.Duplicate(ViewDuplicateOption.AsDependent);                     //duplicate the view as a dependent
                    Autodesk.Revit.DB.View dupView = doc.GetElement(dupViewId) as Autodesk.Revit.DB.View;   //create the dependent view based on the viewID

                    dupView.Name = v.ViewName + "_" + chkbox;   //rename the dependent view as the selected CheckedListbox
                }
            }
        }

        
    }
}


