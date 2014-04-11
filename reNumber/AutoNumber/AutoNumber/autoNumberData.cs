using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Collections;
using System.Xml;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;



namespace AutoNumber
{
    public class autoNumberData
    {
        //FilteredElementCollector m_allCategories = null;
        private CategorySet m_allCategories = new CategorySet();    //store all the CATEGORIES?
        private string m_selectedCategory, m_selectedParameters, m_selectedNumType, m_selectedDirection;
        private int m_selectedStartValue, m_selectedIncrement;
        private bool m_selectionType;
        

        //private Dictionary<int, List<string>> parametersDictionary;
        //private readonly Dictionary<BuiltInParameter, string> builtInParametersNamesDictionary;

        private Dictionary<string, int> catNameList = new Dictionary<string, int>();
        private Dictionary<int, string> paramList = new Dictionary<int, string>();
        private Dictionary<int, List<string>> paramList2 = new Dictionary<int,List<string>>();

        List<string> m_allCatNames = new List<string>();
        List<string> m_allParametersNames = new List<string>();

        //public CategorySet returnAllCategories
        //{
        //    get
        //    {
        //        return m_allCategories;
        //    }
        //}

        public List<string> returnAllCatNames
        {
            get
            {
                return m_allCatNames;
            }
        }

        public List<string> returnAllParametersNames
        {
            get
            {
                return m_allParametersNames;
            }
        }

        public String SelectedCategory
        {
            get
            {
                return m_selectedCategory;
            }
            set
            {
                m_selectedCategory = value;
            }
        }
        public String SelectedParameters
        {
            get
            {
                return m_selectedParameters;
            }
            set
            {
                m_selectedParameters = value;
            }
        }
        public String SelectedNumType
        {
            get
            {
                return m_selectedNumType;
            }
            set
            {
                m_selectedNumType = value;
            }
        }
        public String SelectedDirection
        {
            get
            {
                return m_selectedDirection;
            }
            set
            {
                m_selectedDirection = value;
            }
        }
        public int SelectedStartValue
        {
            get
            {
                return m_selectedStartValue;
            }
            set
            {
                m_selectedStartValue = value;
            }
        }
        public int SelectedIncrement
        {
            get
            {
                return m_selectedIncrement;
            }
            set
            {
                m_selectedIncrement = value;
            }
        }
        public bool SelectionType
        {
            get
            {
                return m_selectionType;
            }

            set
            {
                m_selectionType = value;
            }
        }

        public void refreshList()
        {
            m_allCategories.Clear();
            m_allCatNames.Clear();
            m_allParametersNames.Clear();
            catNameList.Clear();
            paramList.Clear();
        }

        public autoNumberData(Document doc)
        {
            refreshList();
            //call method to get all categories
            GetCategories(doc);


            //call method to get all parameters of each category
            //GetParameters(doc);

        }

        //method to get all categories
        private void GetCategories(Document doc)
        {
            FilteredElementCollector collector = null;

            //collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector = new FilteredElementCollector(doc);

            collector.WhereElementIsNotElementType();
            
            HashSet<int> hashSet1 = new HashSet<int>();     //what is hashset for
            HashSet<BuiltInCategory> hashSet2 = new HashSet<BuiltInCategory>();     // what is hashset for?
            hashSet2.Add((BuiltInCategory)(-2000500));  // OST_Cameras              )
            hashSet2.Add((BuiltInCategory)(-2000535));  // OST_Elev                 )
            hashSet2.Add((BuiltInCategory)(-2003101));  // OST_ProjectInformation   )    not sure what these is?
            hashSet2.Add((BuiltInCategory)(-2000700));  // OST_Materials            )
            hashSet2.Add((BuiltInCategory)(-2000278));  // OST_Viewers              )
            hashSet2.Add((BuiltInCategory)(-2000510));  // OST_Viewports            )
            HashSet<BuiltInCategory> hashSet3 = hashSet2; //what is hashset for?
            
            

            IEnumerator<Element> enumerator;

            using (enumerator = collector.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element elem = enumerator.Current as Element;
                    //HashSet<string> catNames = new HashSet<string>();

                    //check whether selected element category is not null, not in hashSet 3, not an elevation marker, not a View and not a textnote
                    if (elem.Category != null && !hashSet3.Contains((BuiltInCategory)elem.Category.Id.IntegerValue) && (!(elem is ElevationMarker) && !(elem is Autodesk.Revit.DB.View)) && !(elem is TextNote))// || writeableParameters(elem)))
                    {
                        IEnumerator enumerator2 = elem.Parameters.GetEnumerator();
                        List<string> paramName = new List<string>();
                        try
                        {
                            while (enumerator2.MoveNext())
                            {
                                Parameter parameter = enumerator2.Current as Parameter;
                                //check parameters of chosen categories for non-read-only string parameters
                                //if(!parameter.IsReadOnly && parameter.StorageType.ToString().Equals("String"))
                                if (parameter.StorageType.ToString().Equals("String"))
                                {
                                    paramName.Add(parameter.Definition.Name.ToString());  
                                    
                                    //if(!paramList.ContainsKey(elem.Category.Id.IntegerValue))    
                                      //  paramList.Add(elem.Category.Id.IntegerValue, parameter.Definition.Name.ToString());       //   parameter list will be captured in another method
                                                                                                                                  //)
                                    //TaskDialog.Show("test", elem.Category.Name + " + " + parameter.Definition.Name.ToString());   )

                                    string name = elem.Category.Name;

                                    if (!m_allCatNames.Contains(name))
                                    {
                                        m_allCatNames.Add(name);
                                        catNameList.Add(name, elem.Category.Id.IntegerValue);
                                        
                                    }
                                }
                                
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator2 as IDisposable;
                            if (disposable!=null)
                                disposable.Dispose();
                        }
                        if(!paramList2.ContainsKey(elem.Category.Id.IntegerValue))
                            paramList2.Add(elem.Category.Id.IntegerValue, paramName);
                    }
                }
                            

                if (paramList2.Count == 0)
                    TaskDialog.Show("Error", "No Elements with writeable parameters found!\n" + "Please check that current view is correct and try again.");

                ShowDictionary();
            
                //TaskDialog.Show("test", string.Join("\n", paramList.Select(i => i.Key.ToString() + " + " + i.Value.ToString()).ToArray()));
            }
        }


        private void ShowDictionary()       //for testing purposes
        {                      
            string dic1;
            //string dic2;
            string dic3;
            dic1=string.Join("\n", catNameList.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray());
            //dic2 = string.Join("\n", paramList.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()); 
            dic3 = string.Join("\n", paramList2.Select(kv => kv.Key.ToString() + "=" + kv.Value.Select(i=> i.ToString()).ToString()).ToArray()); 

            TaskDialog.Show("category namelist test", dic1);
            //TaskDialog.Show("paramter namelist test", dic2);
            TaskDialog.Show("paramter namelist test", dic3);
        }

       
        public void RefreshParameters()
        {
            
            List<string> updateParams = new List<string>();

            int catID;
            
            updateParams.Clear();
            m_allParametersNames.Clear();

            if (catNameList.TryGetValue(SelectedCategory, out catID))
            {
                
                foreach (KeyValuePair<int, List<string>> p in paramList2)
                {
                    if (p.Key.Equals(catID))
                    {
                        //if(!updateParams.Contains (p.Value))
                        //    updateParams.Add(p.Value);
                        updateParams.AddRange(p.Value);
                    }
                }
            }
            //m_allParametersNames.Clear();
            m_allParametersNames.AddRange(updateParams.ToArray());

        }

        public void AutoNumberSelected()
        {

        }

        public int GetCategoryId(string s)
        {
            int catID;

            if (catNameList.TryGetValue(s, out catID))
            {
                return catID;
            }
            else
            {
                return 0;
            }
        }
    }


    //Selection Filter to activate the selected category elements in the active view
    internal class CategorySelectionFilter : ISelectionFilter
    {
        private readonly int m_categoryId;

        public CategorySelectionFilter(int categoryId)
        {

            m_categoryId = categoryId;
        }

        public bool AllowElement(Element elem)
        {
            if (elem.Category != null)
                return elem.Category.Id.IntegerValue == m_categoryId;
            else
                return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

    

}
