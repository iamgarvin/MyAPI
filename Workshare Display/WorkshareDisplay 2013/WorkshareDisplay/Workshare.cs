using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Collections;
using System.Xml;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WorkshareDisplay
{

    /// <summary>
    /// Revit 2013 Command Class
    /// </summary>
    /// <remarks></remarks>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class Workshare : IExternalCommand
    {
        #region IExternalCommand Members Implementation
        /// <summary>
        /// Implement this method as an external command for Revit.
        /// </summary>
        /// <param name="commandData">An object that is passed to the external application 
        /// which contains data related to the command, 
        /// such as the application object and active view.</param>
        /// <param name="message">A message that can be set by the external application 
        /// which will be displayed if a failure or cancellation is returned by 
        /// the external command.</param>
        /// <param name="elements">A set of elements to which the external application 
        /// can add elements that are to be highlighted in case of failure or cancellation.</param>
        /// <returns>Return the status of the external command. 
        /// A result of Succeeded means that the API external method functioned as expected. 
        /// Cancelled can be used to signify that the user cancelled the external operation 
        /// at some point. Failure should be returned if the application is unable to proceed with 
        /// the operation.</returns>
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData,
            ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Transaction newTran = null;
            try
            {
                if (null == commandData)
                {
                    throw new ArgumentNullException("commandData");
                }

                Document doc = commandData.Application.ActiveUIDocument.Document;
                ViewsMgr view = new ViewsMgr(doc);


                newTran = new Transaction(doc);
                newTran.Start("AllViews_Sample");

                WorkshareForm dlg = new WorkshareForm(view);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    view.WorksharingDisplay(doc);// generates the sheet after u press OK <-- change to activates the worksharing displaysettings after press okay
                }
                newTran.Commit();

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
    /// Generating a new sheet that has all the selected views placed in.
    /// </summary>
    public class ViewsMgr
    {
        private TreeNode m_allViewsNames = new TreeNode("Views (all)");
        private ViewSet m_allViews = new ViewSet();
        private ViewSet m_selectedViews = new ViewSet();


        /// <summary>
        /// Tree node store all views' names.
        /// </summary>
        public TreeNode AllViewsNames
        {
            get
            {
                return m_allViewsNames;
            }
        }

        /// <summary>
        /// List of all title blocks' names.
        /// </summary>


        /// <summary>
        /// The selected sheet's name.
        /// </summary>


        /// <summary>
        /// Constructor of views object.
        /// </summary>
        /// <param name="doc">the active document</param>
        public ViewsMgr(Document doc)
        {
            GetAllViews(doc);
            //GetTitleBlocks(doc); // no need
        }

        /// <summary>
        /// Finds all the views in the active document.
        /// </summary>
        /// <param name="doc">the active document</param>
        private void GetAllViews(Document doc)
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
                    if (null == objType || objType.Name.Equals("Schedule")
                        || objType.Name.Equals("Drawing Sheet"))
                    {
                        continue;
                    }
                    else
                    {
                        m_allViews.Insert(view);
                        AssortViews(view.Name, objType.Name);
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
            if (type.Equals("Building Elevation"))
            {
                categoryNode.Text = "Elevations [" + type + "]";
            }
            else
            {
                categoryNode.Text = type + "s";
            }
            categoryNode.Nodes.Add(new TreeNode(view));
            AllViewsNames.Nodes.Add(categoryNode);
        }

        /// <summary>
        /// Retrieve the checked view from tree view.
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
        /// Generate sheet in active document.
        /// </summary>
        /// <param name="doc">the currently active document</param>


        /// <summary>
        /// Place all selected views on this sheet's appropriate location.
        /// </summary>
        /// <param name="views">all selected views</param>
        /// <param name="sheet">all views located sheet</param>
        /// 

        public void SetWorksharingDisplayMode(ViewSet views)
        {
            if (0 == m_selectedViews.Size)
            {
                throw new InvalidOperationException("No view be selected, generate sheet be cancelled.");
            }

            else
            {
                foreach (Autodesk.Revit.DB.View v in views)
                {
                    WorksharingDisplayMode displayMode = v.GetWorksharingDisplayMode();
                    v.SetWorksharingDisplayMode(WorksharingDisplayMode.Worksets);
                }
            }
        }

        public void WorksharingDisplay(Document doc)
        {
            SetWorksharingDisplayMode(m_selectedViews);
        }
    }
}
