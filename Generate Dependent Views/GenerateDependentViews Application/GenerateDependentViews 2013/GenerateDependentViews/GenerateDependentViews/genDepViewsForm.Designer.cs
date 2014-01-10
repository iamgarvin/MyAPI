namespace GenerateDependentViews
{
    partial class genDepViewsForm
    {
        private genDepViewsData m_data;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.allPlanViewsGroupBox = new System.Windows.Forms.GroupBox();
            this.allPlanViewsTreeView = new System.Windows.Forms.TreeView();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.viewTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.viewTypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.allPlanViewsGroupBox.SuspendLayout();
            this.viewTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // allPlanViewsGroupBox
            // 
            this.allPlanViewsGroupBox.Controls.Add(this.allPlanViewsTreeView);
            this.allPlanViewsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.allPlanViewsGroupBox.Name = "allPlanViewsGroupBox";
            this.allPlanViewsGroupBox.Size = new System.Drawing.Size(212, 433);
            this.allPlanViewsGroupBox.TabIndex = 0;
            this.allPlanViewsGroupBox.TabStop = false;
            this.allPlanViewsGroupBox.Text = "Plan Views";
            // 
            // allPlanViewsTreeView
            // 
            this.allPlanViewsTreeView.CheckBoxes = true;
            this.allPlanViewsTreeView.Location = new System.Drawing.Point(6, 19);
            this.allPlanViewsTreeView.Name = "allPlanViewsTreeView";
            this.allPlanViewsTreeView.Size = new System.Drawing.Size(200, 408);
            this.allPlanViewsTreeView.TabIndex = 0;
            this.allPlanViewsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.allViewsTreeView_AfterCheck);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(18, 451);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(367, 451);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // viewTypeGroupBox
            // 
            this.viewTypeGroupBox.Controls.Add(this.viewTypeCheckedListBox);
            this.viewTypeGroupBox.Location = new System.Drawing.Point(230, 12);
            this.viewTypeGroupBox.Name = "viewTypeGroupBox";
            this.viewTypeGroupBox.Size = new System.Drawing.Size(212, 433);
            this.viewTypeGroupBox.TabIndex = 5;
            this.viewTypeGroupBox.TabStop = false;
            this.viewTypeGroupBox.Text = "View Type";
            // 
            // viewTypeCheckedListBox
            // 
            this.viewTypeCheckedListBox.CheckOnClick = true;
            this.viewTypeCheckedListBox.FormattingEnabled = true;
            this.viewTypeCheckedListBox.Items.AddRange(new object[] {
            "Door & Window Key Plan",
            "Floor Finish Plan",
            "Reflected Ceiling Plan",
            "Wall Schedule Plan",
            "Waterproofing Key plan",
            "AS Level",
            "Default Dependent View"});
            this.viewTypeCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.viewTypeCheckedListBox.Name = "viewTypeCheckedListBox";
            this.viewTypeCheckedListBox.Size = new System.Drawing.Size(200, 409);
            this.viewTypeCheckedListBox.TabIndex = 0;
            // 
            // genDepViewsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(456, 486);
            this.Controls.Add(this.viewTypeGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.allPlanViewsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "genDepViewsForm";
            this.ShowInTaskbar = false;
            this.Text = "All Views";
            this.Load += new System.EventHandler(this.genDepViewsForm_Load);
            this.allPlanViewsGroupBox.ResumeLayout(false);
            this.viewTypeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox allPlanViewsGroupBox;
        private System.Windows.Forms.TreeView allPlanViewsTreeView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox viewTypeGroupBox;
        private System.Windows.Forms.CheckedListBox viewTypeCheckedListBox;
    }
}