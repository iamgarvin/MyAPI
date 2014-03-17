using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Xml;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AutoNumber
{
    public partial class autoNumberForm : Form
    {
        public autoNumberForm()
        {
            InitializeComponent();
        }

        private void autoNumberForm_Load(object sender, EventArgs e)
        {
            //call the get all categories 
            // call get all parameters for 1st or default category
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //do something

            this.DialogResult = DialogResult.OK;    // set dialog result
            this.Close();     
        }

        //public autoNumberForm(autoNumberData data, Document doc)
        //{
        //    m_data = data;

        //    InitializeComponent();
        //}


        //method to get all categories
        private void GetCategories (Document doc)
        {
            CategorySet allCategories = new CategorySet();
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector.WhereElementIsNotElementType();

            //this.categories = new Dictionary<string, ElementId>();
            //this.parameters = new Dictionary<int, List<string>>();
            cboFamilyCategory.BeginUpdate();
            cboFamilyCategory.Sorted = true;

            string str = null;

            HashSet<int> hashSet1 = new HashSet<int>();     //what is hashset for
            HashSet<BuiltInCategory> hashSet2 = new HashSet<BuiltInCategory>();     // what is hashset for?
            hashSet2.Add((BuiltInCategory)(-2000500));  // )
            hashSet2.Add((BuiltInCategory)(-2000535));  // )
            hashSet2.Add((BuiltInCategory)(-2003101));  // )    not sure what these is?
            hashSet2.Add((BuiltInCategory)(-2000700));  // )
            hashSet2.Add((BuiltInCategory)(-2000278));  // )
            hashSet2.Add((BuiltInCategory)(-2000510));  // )
            HashSet<BuiltInCategory> hashSet3 = hashSet2; //what is hashset for?

            List<string> catNameList = new List<string>();

            IEnumerator<Element> enumerator;

            
            using (enumerator = collector.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Element elem = enumerator.Current as Element;
                    if (elem.Category !=null && !hashSet3.Contains((BuiltInCategory) elem.Category.Id.IntegerValue) && (!(elem is ElevationMarker) &&!(elem is Autodesk.Revit.DB.View)) && (elem is TextNote))
                    //if (elem.Category !=null && !hashSet3.Contains((BuiltInCategory) elem.Category.Id.IntegerValue) && (!(elem is ElevationMarker) &&!(elem is Autodesk.Revit.DB.View)) && (elem is TextNote || FindRWParameters(current)))       // what is FindRWParameters?
                    {
                        string name = elem.Category.Name;
                        catNameList.Add(name);
                    }
                }
            }

            cboFamilyCategory.Items.AddRange(catNameList);
        }

                

        //method to get all parameters in the selected categories

        //check to ensure that increment is correct     //<<<< is this a need?

        //event method when ok button is clicked, dialog result ok and close the dialog box

        //event method for whenever the category is picked, the parameter lists updates


    }
}
