using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace formDataCaptureTest
{

    public class formDataCaptureData
    {
        ExternalCommandData m_command;

        Autodesk.Revit.UI.UIApplication m_application;

        string m_CheckBoxText, m_ListBoxItemText, m_ComboBoxText, m_TextBoxText;
        List<string> m_ChecklistBoxItemText = new List<string>();
        TreeNode m_TreeNodeItemText;

        public string returnCheckBoxText
        {
            get
            {
                return m_CheckBoxText;
            }
        }

        public string returnListBoxItemText
        {
            get
            {
                return m_ListBoxItemText;
            }
        }

        public string returnComboBoxText
        {
            get
            {
                return m_ComboBoxText;
            }
        }

        public string returnTextBoxText
        {
            get
            {
                return m_TextBoxText;
            }
        }

        public List<string> returnChecklistBoxItemText
        {
            get
            {
                return m_ChecklistBoxItemText;
            }
        }

        public TreeNode returnTreeNodeItemText
        {
            get
            {
                return m_TreeNodeItemText;
            }
        }

        public formDataCaptureData(ExternalCommandData commandData)
        {
            m_command = commandData;
            m_application = m_command.Application;
        }

        public void refreshList()
        {
            m_ChecklistBoxItemText.Clear(); //refresh and clear the list variable
        }

        public void getItems(string CheckBoxText, string ListBoxItemText, string ComboBoxText, string TextBoxText, List<string> ChecklistBoxItemText, TreeNode TreeNodeItemText)
        {
            m_CheckBoxText = CheckBoxText;
            m_ChecklistBoxItemText = ChecklistBoxItemText;
            m_ComboBoxText = ComboBoxText;
            m_ListBoxItemText = ListBoxItemText;
            m_TextBoxText = TextBoxText;
            m_TreeNodeItemText = TreeNodeItemText;
        }
    }
}
