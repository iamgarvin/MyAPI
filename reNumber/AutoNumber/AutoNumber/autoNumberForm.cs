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
    partial class autoNumberForm : System.Windows.Forms.Form
    {


        public autoNumberForm(autoNumberData data, Document doc)
        {
            m_data = data;  //refer to autoNumberData instance as m_data in this code
            InitializeComponent(); //begins the form to load
        }

        private void autoNumberForm_Load(object sender, EventArgs e)
        {
            this.cboFamilyCategory.Items.AddRange(m_data.returnAllCatNames.ToArray());     //call the get all categories 
            this.cboFamilyCategory.SelectedIndex = 0;
            //cboParameter.Items.AddRange(m_data.something);          // call get all parameters for 1st or default category

            m_data.SelectedCategory = cboParameter.SelectedText;

            this.cboParameter.Items.AddRange(m_data.returnAllParametersNames.ToArray());

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //do something

            this.DialogResult = DialogResult.OK;    // set dialog result
            this.Close();     
        }

        private void cboFamilyCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call the parameter method whenever the selected index of the family category changes
        }




 

                

        //method to get all parameters in the selected categories

        //check to ensure that increment is correct     //<<<< is this a need?

        //event method when ok button is clicked, dialog result ok and close the dialog box

        //event method for whenever the category is picked, the parameter lists updates


    }
}
