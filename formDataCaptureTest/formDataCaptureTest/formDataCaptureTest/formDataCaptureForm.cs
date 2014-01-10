using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;

namespace formDataCaptureTest
{
    public partial class formDataCaptureForm : System.Windows.Forms.Form
    {
        formDataCaptureData m_data;

        string mmCheckBoxText, mmListBoxItemText, mmComboBoxText, mmTextBoxText;
        List<string> mmChecklistBoxItemText = new List<string>();
        TreeNode mmTreeNodeItemText;

        private formDataCaptureForm()
        {
            InitializeComponent();
        }

        public formDataCaptureForm(formDataCaptureData Data)
        {
            m_data = Data;

            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!this.checkData())
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private bool checkData()
        {
            try
            {

                string newListBoxItemText = listBox1.SelectedItem.ToString();
                string newComboBoxText = comboBox1.SelectedItem.ToString();
                string newTextBoxText = textBox1.Text;
                string newCheckBoxText;
                List<string> newChecklistBoxItemText = null;
                TreeNode newTreeNodeItemText = null;


                if (checkBox1.Checked)
                {
                    newCheckBoxText = checkBox1.Text;
                }
                else if (checkBox2.Checked)
                {
                    newCheckBoxText = checkBox2.Text;
                }
                else if (checkBox2.Checked && checkBox1.Checked)
                {
                    newCheckBoxText = checkBox1.Text + checkBox2.Text;
                }
                else
                {
                    newCheckBoxText = "null";
                }

                m_data.getItems(newCheckBoxText, newListBoxItemText, newComboBoxText, newTextBoxText, newChecklistBoxItemText, newTreeNodeItemText);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Revit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

    }
}
