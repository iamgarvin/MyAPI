namespace FamilyBrowser
{
    partial class FamilyBrowserFrm
    {
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblFamilyBrowser = new System.Windows.Forms.Label();
            this.grpboxThumbnails = new System.Windows.Forms.GroupBox();
            this.picSideElevation = new System.Windows.Forms.PictureBox();
            this.picFrontElevation = new System.Windows.Forms.PictureBox();
            this.picPlanView = new System.Windows.Forms.PictureBox();
            this.pic3D = new System.Windows.Forms.PictureBox();
            this.grpboxProperties = new System.Windows.Forms.GroupBox();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblInstance = new System.Windows.Forms.Label();
            this.lblFamily = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.instanceParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instanceParamData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeParamData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl3D = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblSideElevation = new System.Windows.Forms.Label();
            this.lblFrontElevation = new System.Windows.Forms.Label();
            this.btnFamilyDirectory = new System.Windows.Forms.Button();
            this.txtFamilyDirectory = new System.Windows.Forms.TextBox();
            this.lblFamilyDirectory = new System.Windows.Forms.Label();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.lblThumbnail = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpboxThumbnails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSideElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFrontElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3D)).BeginInit();
            this.grpboxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 69);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(250, 625);
            this.treeView1.TabIndex = 0;
            // 
            // lblFamilyBrowser
            // 
            this.lblFamilyBrowser.AutoSize = true;
            this.lblFamilyBrowser.Location = new System.Drawing.Point(8, 53);
            this.lblFamilyBrowser.Name = "lblFamilyBrowser";
            this.lblFamilyBrowser.Size = new System.Drawing.Size(77, 13);
            this.lblFamilyBrowser.TabIndex = 6;
            this.lblFamilyBrowser.Text = "Family Browser";
            // 
            // grpboxThumbnails
            // 
            this.grpboxThumbnails.Controls.Add(this.lblFrontElevation);
            this.grpboxThumbnails.Controls.Add(this.lblSideElevation);
            this.grpboxThumbnails.Controls.Add(this.lblPlan);
            this.grpboxThumbnails.Controls.Add(this.lbl3D);
            this.grpboxThumbnails.Controls.Add(this.picSideElevation);
            this.grpboxThumbnails.Controls.Add(this.lblThumbnail);
            this.grpboxThumbnails.Controls.Add(this.picFrontElevation);
            this.grpboxThumbnails.Controls.Add(this.picPlanView);
            this.grpboxThumbnails.Controls.Add(this.picThumbnail);
            this.grpboxThumbnails.Controls.Add(this.pic3D);
            this.grpboxThumbnails.Location = new System.Drawing.Point(268, 11);
            this.grpboxThumbnails.Name = "grpboxThumbnails";
            this.grpboxThumbnails.Size = new System.Drawing.Size(445, 444);
            this.grpboxThumbnails.TabIndex = 7;
            this.grpboxThumbnails.TabStop = false;
            this.grpboxThumbnails.Text = "Thumbnails";
            // 
            // picSideElevation
            // 
            this.picSideElevation.Location = new System.Drawing.Point(315, 313);
            this.picSideElevation.Name = "picSideElevation";
            this.picSideElevation.Size = new System.Drawing.Size(120, 120);
            this.picSideElevation.TabIndex = 0;
            this.picSideElevation.TabStop = false;
            // 
            // picFrontElevation
            // 
            this.picFrontElevation.Location = new System.Drawing.Point(315, 174);
            this.picFrontElevation.Name = "picFrontElevation";
            this.picFrontElevation.Size = new System.Drawing.Size(120, 120);
            this.picFrontElevation.TabIndex = 0;
            this.picFrontElevation.TabStop = false;
            // 
            // picPlanView
            // 
            this.picPlanView.Location = new System.Drawing.Point(315, 35);
            this.picPlanView.Name = "picPlanView";
            this.picPlanView.Size = new System.Drawing.Size(120, 120);
            this.picPlanView.TabIndex = 0;
            this.picPlanView.TabStop = false;
            // 
            // pic3D
            // 
            this.pic3D.Location = new System.Drawing.Point(9, 35);
            this.pic3D.Name = "pic3D";
            this.pic3D.Size = new System.Drawing.Size(300, 205);
            this.pic3D.TabIndex = 0;
            this.pic3D.TabStop = false;
            // 
            // grpboxProperties
            // 
            this.grpboxProperties.Controls.Add(this.dgvParameters);
            this.grpboxProperties.Controls.Add(this.lblParameters);
            this.grpboxProperties.Controls.Add(this.lblFileName);
            this.grpboxProperties.Controls.Add(this.lblInstance);
            this.grpboxProperties.Controls.Add(this.lblFamily);
            this.grpboxProperties.Controls.Add(this.textBox3);
            this.grpboxProperties.Controls.Add(this.textBox2);
            this.grpboxProperties.Controls.Add(this.txtFileName);
            this.grpboxProperties.Location = new System.Drawing.Point(268, 461);
            this.grpboxProperties.Name = "grpboxProperties";
            this.grpboxProperties.Size = new System.Drawing.Size(445, 233);
            this.grpboxProperties.TabIndex = 8;
            this.grpboxProperties.TabStop = false;
            this.grpboxProperties.Text = "Properties";
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.instanceParam,
            this.instanceParamData,
            this.typeParam,
            this.typeParamData});
            this.dgvParameters.Location = new System.Drawing.Point(6, 115);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.ReadOnly = true;
            this.dgvParameters.RowHeadersWidth = 4;
            this.dgvParameters.Size = new System.Drawing.Size(429, 104);
            this.dgvParameters.TabIndex = 13;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(6, 99);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(60, 13);
            this.lblParameters.TabIndex = 12;
            this.lblParameters.Text = "Parameters";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 21);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 11;
            this.lblFileName.Text = "File Name";
            // 
            // lblInstance
            // 
            this.lblInstance.AutoSize = true;
            this.lblInstance.Location = new System.Drawing.Point(229, 60);
            this.lblInstance.Name = "lblInstance";
            this.lblInstance.Size = new System.Drawing.Size(48, 13);
            this.lblInstance.TabIndex = 10;
            this.lblInstance.Text = "Instance";
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Location = new System.Drawing.Point(6, 60);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(36, 13);
            this.lblFamily.TabIndex = 9;
            this.lblFamily.Text = "Family";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(232, 76);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(203, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 20);
            this.textBox2.TabIndex = 7;
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(6, 37);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(429, 20);
            this.txtFileName.TabIndex = 8;
            // 
            // instanceParam
            // 
            this.instanceParam.HeaderText = "Instance Parameter";
            this.instanceParam.MinimumWidth = 3;
            this.instanceParam.Name = "instanceParam";
            this.instanceParam.ReadOnly = true;
            this.instanceParam.Width = 120;
            // 
            // instanceParamData
            // 
            this.instanceParamData.HeaderText = "Instance Value";
            this.instanceParamData.Name = "instanceParamData";
            this.instanceParamData.ReadOnly = true;
            // 
            // typeParam
            // 
            this.typeParam.HeaderText = "Type Parameter";
            this.typeParam.Name = "typeParam";
            this.typeParam.ReadOnly = true;
            // 
            // typeParamData
            // 
            this.typeParamData.HeaderText = "Type Value";
            this.typeParamData.Name = "typeParamData";
            this.typeParamData.ReadOnly = true;
            // 
            // lbl3D
            // 
            this.lbl3D.AutoSize = true;
            this.lbl3D.Location = new System.Drawing.Point(9, 19);
            this.lbl3D.Name = "lbl3D";
            this.lbl3D.Size = new System.Drawing.Size(47, 13);
            this.lbl3D.TabIndex = 1;
            this.lbl3D.Text = "3D View";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(315, 19);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 1;
            this.lblPlan.Text = "Plan";
            // 
            // lblSideElevation
            // 
            this.lblSideElevation.AutoSize = true;
            this.lblSideElevation.Location = new System.Drawing.Point(315, 297);
            this.lblSideElevation.Name = "lblSideElevation";
            this.lblSideElevation.Size = new System.Drawing.Size(75, 13);
            this.lblSideElevation.TabIndex = 1;
            this.lblSideElevation.Text = "Side Elevation";
            // 
            // lblFrontElevation
            // 
            this.lblFrontElevation.AutoSize = true;
            this.lblFrontElevation.Location = new System.Drawing.Point(315, 158);
            this.lblFrontElevation.Name = "lblFrontElevation";
            this.lblFrontElevation.Size = new System.Drawing.Size(78, 13);
            this.lblFrontElevation.TabIndex = 1;
            this.lblFrontElevation.Text = "Front Elevation";
            // 
            // btnFamilyDirectory
            // 
            this.btnFamilyDirectory.Location = new System.Drawing.Point(229, 30);
            this.btnFamilyDirectory.Name = "btnFamilyDirectory";
            this.btnFamilyDirectory.Size = new System.Drawing.Size(33, 23);
            this.btnFamilyDirectory.TabIndex = 5;
            this.btnFamilyDirectory.Text = "...";
            this.btnFamilyDirectory.UseVisualStyleBackColor = true;
            // 
            // txtFamilyDirectory
            // 
            this.txtFamilyDirectory.Enabled = false;
            this.txtFamilyDirectory.Location = new System.Drawing.Point(11, 30);
            this.txtFamilyDirectory.Name = "txtFamilyDirectory";
            this.txtFamilyDirectory.Size = new System.Drawing.Size(212, 20);
            this.txtFamilyDirectory.TabIndex = 10;
            // 
            // lblFamilyDirectory
            // 
            this.lblFamilyDirectory.AutoSize = true;
            this.lblFamilyDirectory.Location = new System.Drawing.Point(12, 11);
            this.lblFamilyDirectory.Name = "lblFamilyDirectory";
            this.lblFamilyDirectory.Size = new System.Drawing.Size(81, 13);
            this.lblFamilyDirectory.TabIndex = 11;
            this.lblFamilyDirectory.Text = "Family Directory";
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(9, 259);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(300, 174);
            this.picThumbnail.TabIndex = 0;
            this.picThumbnail.TabStop = false;
            // 
            // lblThumbnail
            // 
            this.lblThumbnail.AutoSize = true;
            this.lblThumbnail.Location = new System.Drawing.Point(9, 243);
            this.lblThumbnail.Name = "lblThumbnail";
            this.lblThumbnail.Size = new System.Drawing.Size(56, 13);
            this.lblThumbnail.TabIndex = 1;
            this.lblThumbnail.Text = "Thumbnail";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(536, 701);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(628, 701);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FamilyBrowserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 736);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblFamilyDirectory);
            this.Controls.Add(this.txtFamilyDirectory);
            this.Controls.Add(this.btnFamilyDirectory);
            this.Controls.Add(this.grpboxProperties);
            this.Controls.Add(this.grpboxThumbnails);
            this.Controls.Add(this.lblFamilyBrowser);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FamilyBrowserFrm";
            this.Text = "RSP Family Browser";
            this.grpboxThumbnails.ResumeLayout(false);
            this.grpboxThumbnails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSideElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFrontElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3D)).EndInit();
            this.grpboxProperties.ResumeLayout(false);
            this.grpboxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblFamilyBrowser;
        private System.Windows.Forms.GroupBox grpboxThumbnails;
        private System.Windows.Forms.PictureBox picSideElevation;
        private System.Windows.Forms.PictureBox picFrontElevation;
        private System.Windows.Forms.PictureBox picPlanView;
        private System.Windows.Forms.PictureBox pic3D;
        private System.Windows.Forms.GroupBox grpboxProperties;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblInstance;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn instanceParamData;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeParamData;
        private System.Windows.Forms.Label lblFrontElevation;
        private System.Windows.Forms.Label lblSideElevation;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lbl3D;
        private System.Windows.Forms.Button btnFamilyDirectory;
        private System.Windows.Forms.TextBox txtFamilyDirectory;
        private System.Windows.Forms.Label lblFamilyDirectory;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.Label lblThumbnail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}