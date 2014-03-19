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
        private string m_selectedCategory;

        //private Dictionary<int, List<string>> parametersDictionary;
        //private readonly Dictionary<BuiltInParameter, string> builtInParametersNamesDictionary;

        private Dictionary<int, string> catNameList = new Dictionary<int, string>();
        private Dictionary<int, string> paramList = new Dictionary<int, string>();

        List<string> m_allCatNames = new List<string>();
        List<string> m_allParametersNames = new List<string>();

        public CategorySet returnAllCategories
        {
            get
            {
                return m_allCategories;
            }
        }

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

        public void refreshList()
        {
            m_allCategories.Clear();
            m_allCatNames.Clear();
            m_allParametersNames.Clear();
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
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector.WhereElementIsNotElementType();
            
            HashSet<int> hashSet1 = new HashSet<int>();     //what is hashset for
            HashSet<BuiltInCategory> hashSet2 = new HashSet<BuiltInCategory>();     // what is hashset for?
            hashSet2.Add((BuiltInCategory)(-2000500));  // )
            hashSet2.Add((BuiltInCategory)(-2000535));  // )
            hashSet2.Add((BuiltInCategory)(-2003101));  // )    not sure what these is?
            hashSet2.Add((BuiltInCategory)(-2000700));  // )
            hashSet2.Add((BuiltInCategory)(-2000278));  // )
            hashSet2.Add((BuiltInCategory)(-2000510));  // )
            HashSet<BuiltInCategory> hashSet3 = hashSet2; //what is hashset for?

            

            IEnumerator<Element> enumerator;

            using (enumerator = collector.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element elem = enumerator.Current as Element;
                    //HashSet<string> catNames = new HashSet<string>();

                    if (elem.Category != null && !hashSet3.Contains((BuiltInCategory)elem.Category.Id.IntegerValue) && (!(elem is ElevationMarker) && !(elem is Autodesk.Revit.DB.View)) && !(elem is TextNote))// || writeableParameters(elem)))
                    {

                        
                        IEnumerator enumerator2 = elem.Parameters.GetEnumerator();
                        try
                        {
                            while (enumerator2.MoveNext())
                            {
                                Parameter parameter = enumerator2.Current as Parameter;
                                if(!parameter.IsReadOnly && parameter.StorageType.ToString().Equals("String"))
                                {
                                    string paramName = parameter.Definition.Name.ToString();
                                    if(!paramList.ContainsKey(elem.Category.Id.IntegerValue))
                                        paramList.Add(elem.Category.Id.IntegerValue, paramName);
                                }
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator2 as IDisposable;
                            if (disposable!=null)
                                disposable.Dispose();
                        }
                        
                        if(paramList.Count == 0) 
                            continue;
                        else
                        {

                            string name = elem.Category.Name;

                            if (!m_allCatNames.Contains(name))
                            {
                                m_allCatNames.Add(name);
                                catNameList.Add(elem.Category.Id.IntegerValue, name);
                            }
                        }
                    }
                }

                
                string dic1;
                string dic2;

                dic1=string.Join("\n", paramList.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray());
                dic2=string.Join("\n", catNameList.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray());

                TaskDialog.Show("test", dic1);
                TaskDialog.Show("test", dic2);

            }
        }

        
        

        
       
        public void GetParameters(Document doc)
        {
            //if elem.category.name is equals to selectedCat, then extract the parameters that are not readonly and storage type is String
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector.WhereElementIsNotElementType();

            IEnumerator<Element> enumerator;

            using (enumerator = collector.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element elem = enumerator.Current as Element;

                    if (elem.Category.Name.ToString().Equals(SelectedCategory))
                    {
                        IEnumerator enumerator2 = elem.Parameters.GetEnumerator();
                        try
                        {
                            while (enumerator2.MoveNext())
                            {
                                Parameter parameter = enumerator2.Current as Parameter;
                                if (!parameter.IsReadOnly && parameter.StorageType.ToString().Equals("String"))
                                {
                                    string paramName = parameter.Definition.Name.ToString();
                                    if (!m_allParametersNames.Contains(paramName))
                                    {
                                        m_allParametersNames.Add(paramName);
                                    }


                                }
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator2 as IDisposable;
                            if (disposable != null)
                                disposable.Dispose();
                        }
                    }
                }
            }
        }

        //internal NumberGenerator(

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
