namespace WorkshareDisplay
{
    partial class WorkshareForm
    {
        private ViewsMgr m_data;
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
            this.allViewsGroupBox = new System.Windows.Forms.GroupBox();
            this.allViewsTreeView = new System.Windows.Forms.TreeView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.oKButton = new System.Windows.Forms.Button();
            this.allViewsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // allViewsGroupBox
            // 
            this.allViewsGroupBox.Controls.Add(this.allViewsTreeView);
            this.allViewsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.allViewsGroupBox.Name = "allViewsGroupBox";
            this.allViewsGroupBox.Size = new System.Drawing.Size(212, 433);
            this.allViewsGroupBox.TabIndex = 0;
            this.allViewsGroupBox.TabStop = false;
            this.allViewsGroupBox.Text = "All Views";
            // 
            // allViewsTreeView
            // 
            this.allViewsTreeView.CheckBoxes = true;
            this.allViewsTreeView.Location = new System.Drawing.Point(6, 19);
            this.allViewsTreeView.Name = "allViewsTreeView";
            this.allViewsTreeView.Size = new System.Drawing.Size(200, 408);
            this.allViewsTreeView.TabIndex = 0;
            this.allViewsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.allViewsTreeView_AfterCheck);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(143, 451);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // oKButton
            // 
            this.oKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.oKButton.Location = new System.Drawing.Point(18, 451);
            this.oKButton.Name = "oKButton";
            this.oKButton.Size = new System.Drawing.Size(75, 23);
            this.oKButton.TabIndex = 3;
            this.oKButton.Text = "&OK";
            this.oKButton.UseVisualStyleBackColor = true;
            this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
            // 
            // WorkshareForm
            // 
            this.AcceptButton = this.oKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(242, 486);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.oKButton);
            this.Controls.Add(this.allViewsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkshareForm";
            this.ShowInTaskbar = false;
            this.Text = "All Views";
            this.Load += new System.EventHandler(this.AllViewsForm_Load);
            this.allViewsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox allViewsGroupBox;
        private System.Windows.Forms.Button oKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TreeView allViewsTreeView;
    }
}