using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;

namespace projectCoordinatesSetup
{

    public partial class projectCoordinatesForm : System.Windows.Forms.Form
    {
        projectCoordinatesData m_data; //the reference of the projectCoordinatesData class
        
        string m_currentName; //the current project location's name;
        string m_newLocationName; //the name of the duplicated location

        private SiteLocation m_siteLocation;     //reference to SiteLocation
        private const int DecimalNumber = 3;     //number of decimal
        private bool m_isFormLoading = true;     //indicate whether called when Form loading

        private projectCoordinatesForm()
        {
            InitializeComponent();
        }

        public projectCoordinatesForm(projectCoordinatesData data, SiteLocation siteLocation)
        {
            m_data = data;
            m_currentName = null;
            m_siteLocation = siteLocation;
            
            InitializeComponent();
        }

        private void DisplayInformation() //display location names in the listbox
        {
            locationListBox.Items.Clear(); //initialize the listbox
            foreach (string itemName in m_data.getProjectLocationNames)
            {
                if (itemName == m_data.getSetLocationName)
                {
                    m_currentName = itemName + " (current)"; //indicate the current project location
                    locationListBox.Items.Add(m_currentName);
                }
                else
                {
                    locationListBox.Items.Add(itemName);
                }
            }

            for (int i = 0; i < locationListBox.Items.Count; i++) //set the selected item to current location
            {
                string itemName = null;
                itemName = locationListBox.Items[i].ToString();
                if (itemName.Contains("(current)"))
                {
                    locationListBox.SelectedIndex = i;
                }
            }

            string selecteName = locationListBox.SelectedItem.ToString();
            m_data.GetOffset(selecteName);

            m_isFormLoading = false;
        }

        private void projectCoordinatesForm_Load(object sender, EventArgs e)
        {
            this.DisplayInformation();
        }

        private void okButton_Click(object sender, EventArgs e) // close the form and return true
        {
            if (!this.checkData())
            {
                return;
            }
            updateSiteLocation();
            this.DialogResult = DialogResult.OK;    // set dialog result
            this.Close();                           // close the form
        }

        private bool checkData() //check the user inputs
        {
            try
            {
                string newValue = trueNorthTextBox.Text;
                string degree = ((char)0xb0).ToString();
                if (newValue.Contains(degree))
                {
                    int index = newValue.IndexOf(degree);
                    newValue = newValue.Substring(0, index);
                }
                double newAngle = Convert.ToDouble(newValue);
                double newEast = Convert.ToDouble(eastingTextBox.Text);
                double newNorth = Convert.ToDouble(northingTextBox.Text);
                double newElevation = Convert.ToDouble(elevationTextBox.Text);
                string positionName = locationListBox.SelectedItem.ToString();
                string newRotation = trueNorthComboBox.SelectedItem.ToString();

                m_data.EditPosition(positionName, newAngle, newEast, newNorth, newElevation, newRotation);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please input a number in TextBox.", "Revit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please input Rotation Direction.", "Revit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Revit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private string convertDecimalToString(string value)
        {
            string result;
            double doubleValue;
            //try to get double value from string
            if (!unitConverter.StringToDouble(value, ValueType.Angle, out doubleValue))
            {
                string degree = ((char)0xb0).ToString();
                if (!value.Contains(degree))
                {
                    result = value + degree;
                    return result;
                }
            }
            //try to convert double into string
            result = unitConverter.DoubleToString(doubleValue, ValueType.Angle);
            return result;
        }

        private void updateSiteLocation() //update the Site Location
        {
            if (null == m_siteLocation)
            {
                return;
            }
        }

        private void trueNorthTextBox_Leave(object sender, EventArgs e) //put degree symbol in angle text box
        {
            try
            {
                //check is there any symbol exist in the behind of the value
                //and check whether the user's input is number 
                string degree = ((char)0xb0).ToString();
                if (!trueNorthTextBox.Text.Contains(degree))
                {
                    double value = Convert.ToDouble(trueNorthTextBox.Text);
                    trueNorthTextBox.AppendText(degree);
                }
                else
                {
                    string tempName = trueNorthTextBox.Text;
                    int index = tempName.IndexOf(degree);
                    tempName = tempName.Substring(0, index);
                    double value = Convert.ToDouble(tempName);
                }
            }
            catch (FormatException)
            {
                //angle text boxes should only input number information
                MessageBox.Show("Please input double number in TextBox.", "Revit",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                // if other unexpected error, just show the information
                MessageBox.Show(ex.Message, "Revit",
                                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}


