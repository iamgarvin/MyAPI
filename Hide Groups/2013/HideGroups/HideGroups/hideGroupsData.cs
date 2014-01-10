using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;



namespace HideGroups
{
    public class hideGroupsData
    {

        // Store the reference of the application in revit
        
        private ViewSet m_allViews = new ViewSet(); //store all the PLAN views
        List<Group> m_groups = new List<Group>();   // store all the groups << consider to convert to DETAIL GROUPS only
        List<string> m_allViewsNames = new List<string>();
        List<string> m_allGroupsNames = new List <string>();
        List<ElementId> m_grpElementId = new List<ElementId>();
        public string[] viewstring = new string[] {"DOOR & WINDOW KEY PLAN", "FLOOR FINISH PLAN", "REFLECTED CEILING PLAN", "WALL SCHEDULE PLAN", "WATERPROOFING KEY PLAN", "FIRE COMPARTMENTATION PLAN"};
        public string[] grpstring = new string[] { "DOOR & WINDOW", "FLOOR FINISH", "REFLECTED CEILING", "WALL TAG", "WATERPROOFING", "FIRE COMPARTMENTATION" };


        public ViewSet returnAllViews
        {
            get
            {
                return m_allViews;
            }
        }
        public List<Group> returnAllGroups
        {
            get
            {
                return m_groups;
            }
        }
        public List<string> returnAllViewsNames
        {
            get
            {
                return m_allViewsNames;
            }
        }
        public List<string> returnAllGroupsNames
        {
            get
            {
                return m_allGroupsNames;
            }
        }
        public List<ElementId> returnAllGrpElementIDs
        {
            get
            {
                return m_grpElementId;
            }
        }
     
        public void refreshList() //refresh and clear all the list variables
        {
            m_groups.Clear();
            m_allViewsNames.Clear();
            m_allGroupsNames.Clear();
        }

        public hideGroupsData(Document doc)
        {
            refreshList();
            GetPlanViews(doc);
            GetGroups(doc);

            GetGrpNames();
            GetViewNames();
            //CleanGroups();
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
                        
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Find all the Groups in the document
        /// </summary>
        private void GetGroups(Document doc)
        {
            //Document doc = m_revit.ActiveUIDocument.Document;

            FilteredElementCollector grpCollector = new FilteredElementCollector(doc);
            FilteredElementIterator grpItor = grpCollector.OfClass(typeof(Autodesk.Revit.DB.Group)).GetElementIterator();
            grpItor.Reset();

            while (grpItor.MoveNext())
            {
                Group group = grpItor.Current as Group;
                if (null == group || group.Category.Name != "Detail Groups")
                {
                    continue;
                }
                else if (group.Name.ToString().ToUpper().Contains(grpstring[0]) || group.Name.ToString().ToUpper().Contains(grpstring[1]) || group.Name.ToString().ToUpper().Contains(grpstring[2]) || group.Name.ToString().ToUpper().Contains(grpstring[3]) || group.Name.ToString().ToUpper().Contains(grpstring[4]) || group.Name.ToString().ToUpper().Contains(grpstring[5]) )
                {
                    ElementType objType = doc.GetElement(group.GetTypeId()) as ElementType;
                    
                    m_groups.Add(group);
                   
                }
            }
        }

        private void GetGrpNames()
        {
            foreach (Group g in m_groups)
            {
                m_allGroupsNames.Add(g.Name.ToString());
            }
        }
        private void GetViewNames()
        {
            foreach (View v in m_allViews)
            {
                m_allViewsNames.Add(v.Name.ToString());
            }
        }

        private void getGrpElements(Group grp)
        {
            m_grpElementId.Clear();
            m_grpElementId.AddRange(grp.GetMemberIds());
        }

        public void CleanGroups(string s1, string s2)
        {
            
            foreach (View v in m_allViews)
            {
                
                if (!v.Name.ToString().ToUpper().Contains(s1))
                {
                    foreach (Group g in m_groups)
                    {
                        if (g.Name.ToString().ToUpper().Contains(s2))
                        {
                            getGrpElements(g);
                            //v.HideElements(g.Id);
                            v.HideElements(m_grpElementId);
                        }
                    }
                }
            }
        }

       

//        public void GetInfo_Group(Group group)
//        {
//            string message = "Group : ";

            // Show the group type name
//            message += "\nGroup type name is : " + group.GroupType.Name;

            // Show the name of the elements contained in the group
//            message += "\nThe members contained in this group are:";
//            foreach (Element member in group.Members)
//            {
//                message += "\n\tGroup member id : " + member.Id.IntegerValue;
//            }

            //message += "\nAll member will now be removed from group.";
            //group.Ungroup();

//            TaskDialog.Show("Revit", message);
//        }       // WAIT FIRST





    }
}
