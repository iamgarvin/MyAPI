using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        //method to get all parameters in the selected categories

        //check to ensure that increment is correct     //<<<< is this a need?

        //event method when ok button is clicked, dialog result ok and close the dialog box

        //event method for whenever the category is picked, the parameter lists updates


    }
}
