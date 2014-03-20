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

            m_data.SelectedCategory = cboFamilyCategory.SelectedItem.ToString();
            m_data.RefreshParameters();
            this.cboParameter.Items.Clear();
            this.cboParameter.Items.AddRange(m_data.returnAllParametersNames.ToArray());
            this.cboParameter.SelectedIndex = 0;

            this.cboNumberingType.SelectedIndex = 0;
            this.updwnIncrement.Value = 1;
            //this.updwnIncrement.Update();
            this.updwnStartValue.Value = 1;
            //this.updwnStartValue.Update();
            this.cboDirection.SelectedIndex = 0;



        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //call method to extract the selected values
            GetValues(cboFamilyCategory.SelectedItem.ToString(), cboParameter.SelectedItem.ToString(), cboNumberingType.SelectedItem.ToString(), (int)updwnStartValue.Value, (int)updwnIncrement.Value, cboDirection.SelectedItem.ToString(), rbtnManualSelect.Checked);

            m_data.AutoNumberSelected();

            this.DialogResult = DialogResult.OK;    // set dialog result
            this.Close();     
        }

        private void cboFamilyCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //call the parameter method whenever the selected index of the family category changes
            m_data.SelectedCategory = cboFamilyCategory.SelectedItem.ToString();
            m_data.RefreshParameters();
            this.cboParameter.Items.Clear();
            this.cboParameter.Items.AddRange(m_data.returnAllParametersNames.ToArray());
            this.cboParameter.SelectedIndex = 0;
        }



        private void GetValues(string c, string p, string num, int start, int inc, string dir, bool sel)
        {
            m_data.SelectedCategory = c;
            m_data.SelectedParameters = p;
            m_data.SelectedNumType = num;
            m_data.SelectedStartValue = start;
            m_data.SelectedIncrement = inc;
            m_data.SelectedDirection = dir;

            if (rbtnManualSelect.Checked)
                m_data.SelectionType = true;
            else
                m_data.SelectionType = false;

        }

        private void rbtnManualSelect_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnSelectAll.Checked.Equals(rbtnManualSelect.Checked))
            {
                rbtnSelectAll.Checked = !rbtnManualSelect.Checked;
            }

        }

        private void rbtnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnManualSelect.Checked.Equals(rbtnSelectAll.Checked))
            {
                rbtnManualSelect.Checked = !rbtnSelectAll.Checked;
            }
        }
 

                

        //method to get all parameters in the selected categories

        //check to ensure that increment is correct     //<<<< is this a need?

        //event method when ok button is clicked, dialog result ok and close the dialog box

        //event method for whenever the category is picked, the parameter lists updates


    }
}
