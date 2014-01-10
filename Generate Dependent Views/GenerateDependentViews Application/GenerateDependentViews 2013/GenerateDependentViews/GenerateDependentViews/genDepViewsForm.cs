using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GenerateDependentViews
{
    /// <summary>
    /// This is a dialog should appear that contains the following:
    /// A tree view represents all the plan views.
    /// A Checked Listbox of different types of dependent views
    /// </summary>

    public partial class genDepViewsForm : Form
    {
        /// <summary>
        /// main form method to call the class from genDepViewsData and Initialize the Component
        /// </summary>
        /// <param name="data"></param>
        public genDepViewsForm(genDepViewsData data)
        {
            m_data = data;//refer genDepViewsData instance as m_data in this code
            InitializeComponent(); //begins the form to load
        }

        /// <summary>
        /// load the template form and list out the names of all plan views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genDepViewsForm_Load(object sender, EventArgs e) //form loads
        {
            allPlanViewsTreeView.Nodes.Add(m_data.AllViewsNames);//allPlanViews Tree View adds Nodes from the genDepViewsData instance's AllViewsNames variable
            allPlanViewsTreeView.TopNode.Expand(); //expland the top node of AllPlanViews Tree View
            
        }

        /// <summary>
        /// confirmation with okay button, to perform retrieval of selectedPlanViews and checked dependent view types
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e) //action when the ok button is clicked
        {
            m_data.SelectViews(); //activates the SelectViews method in the genDepViewsData // SelectViews is to retrieve the checked nodes in the AllPlanViews Tree
            ///m_data.SelectDependentViewTypes(doorWindowKeyChkBox, floorFinishCboBox, reflectedCeilingChkBox, wallScheduleChkBox, waterproofingKeyChkBox, asLevelChkBox, defaultDepViewChkBox);

            m_data.getCheckedItemsCheckedListBox(viewTypeCheckedListBox);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// check node method to search and check the checkstatus of each treenode
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void CheckNode(TreeNode node, bool check)
        {
            if (0 < node.Nodes.Count)
            {
                if (node.Checked)
                {
                    node.Expand();
                }
                else
                {
                    node.Collapse();
                }

                foreach (TreeNode t in node.Nodes)
                {
                    t.Checked = check;
                    CheckNode(t, check);
                }
            }
        }

        /// <summary>
        /// check that nodes in the treeview are checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allViewsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckNode(e.Node, e.Node.Checked);
        }
    }
}