namespace AutoNumber
{
    partial class autoNumberForm
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
            this.components = new System.ComponentModel.Container();
            this.updwnIncrement = new System.Windows.Forms.NumericUpDown();
            this.updwnStartValue = new System.Windows.Forms.NumericUpDown();
            this.cboParameter = new System.Windows.Forms.ComboBox();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.cboNumberingType = new System.Windows.Forms.ComboBox();
            this.cboFamilyCategory = new System.Windows.Forms.ComboBox();
            this.lblNumberingType = new System.Windows.Forms.Label();
            this.lblParameter = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblIncrement = new System.Windows.Forms.Label();
            this.lblStartValue = new System.Windows.Forms.Label();
            this.lblInclude = new System.Windows.Forms.Label();
            this.lblFamilyCategory = new System.Windows.Forms.Label();
            this.chklstboxInclude = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.autoNumberFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.updwnIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwnStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoNumberFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // updwnIncrement
            // 
            this.updwnIncrement.Location = new System.Drawing.Point(98, 119);
            this.updwnIncrement.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.updwnIncrement.Name = "updwnIncrement";
            this.updwnIncrement.Size = new System.Drawing.Size(120, 20);
            this.updwnIncrement.TabIndex = 19;
            this.updwnIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // updwnStartValue
            // 
            this.updwnStartValue.Location = new System.Drawing.Point(98, 93);
            this.updwnStartValue.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.updwnStartValue.Name = "updwnStartValue";
            this.updwnStartValue.Size = new System.Drawing.Size(120, 20);
            this.updwnStartValue.TabIndex = 20;
            this.updwnStartValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboParameter
            // 
            this.cboParameter.FormattingEnabled = true;
            this.cboParameter.Location = new System.Drawing.Point(97, 39);
            this.cboParameter.Name = "cboParameter";
            this.cboParameter.Size = new System.Drawing.Size(121, 21);
            this.cboParameter.TabIndex = 15;
            // 
            // cboDirection
            // 
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Up",
            "Down"});
            this.cboDirection.Location = new System.Drawing.Point(97, 145);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(121, 21);
            this.cboDirection.TabIndex = 16;
            this.cboDirection.Text = "Choose Direction";
            // 
            // cboNumberingType
            // 
            this.cboNumberingType.FormattingEnabled = true;
            this.cboNumberingType.Items.AddRange(new object[] {
            "Numeric",
            "Alphabetic (Upper)",
            "Alphabetic (Lower)",
            "Roman Numeric (Upper)",
            "Roman Numeric (Lower)"});
            this.cboNumberingType.Location = new System.Drawing.Point(97, 66);
            this.cboNumberingType.Name = "cboNumberingType";
            this.cboNumberingType.Size = new System.Drawing.Size(121, 21);
            this.cboNumberingType.TabIndex = 17;
            this.cboNumberingType.Text = "Select No. Type";
            // 
            // cboFamilyCategory
            // 
            this.cboFamilyCategory.FormattingEnabled = true;
            this.cboFamilyCategory.Location = new System.Drawing.Point(97, 12);
            this.cboFamilyCategory.Name = "cboFamilyCategory";
            this.cboFamilyCategory.Size = new System.Drawing.Size(121, 21);
            this.cboFamilyCategory.TabIndex = 18;
            // 
            // lblNumberingType
            // 
            this.lblNumberingType.AutoSize = true;
            this.lblNumberingType.Location = new System.Drawing.Point(6, 69);
            this.lblNumberingType.Name = "lblNumberingType";
            this.lblNumberingType.Size = new System.Drawing.Size(85, 13);
            this.lblNumberingType.TabIndex = 8;
            this.lblNumberingType.Text = "Numbering Type";
            // 
            // lblParameter
            // 
            this.lblParameter.AutoSize = true;
            this.lblParameter.Location = new System.Drawing.Point(36, 42);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(55, 13);
            this.lblParameter.TabIndex = 9;
            this.lblParameter.Text = "Parameter";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(42, 148);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(49, 13);
            this.lblDirection.TabIndex = 10;
            this.lblDirection.Text = "Direction";
            // 
            // lblIncrement
            // 
            this.lblIncrement.AutoSize = true;
            this.lblIncrement.Location = new System.Drawing.Point(33, 121);
            this.lblIncrement.Name = "lblIncrement";
            this.lblIncrement.Size = new System.Drawing.Size(54, 13);
            this.lblIncrement.TabIndex = 11;
            this.lblIncrement.Text = "Increment";
            // 
            // lblStartValue
            // 
            this.lblStartValue.AutoSize = true;
            this.lblStartValue.Location = new System.Drawing.Point(33, 95);
            this.lblStartValue.Name = "lblStartValue";
            this.lblStartValue.Size = new System.Drawing.Size(59, 13);
            this.lblStartValue.TabIndex = 12;
            this.lblStartValue.Text = "Start Value";
            // 
            // lblInclude
            // 
            this.lblInclude.AutoSize = true;
            this.lblInclude.Location = new System.Drawing.Point(224, 15);
            this.lblInclude.Name = "lblInclude";
            this.lblInclude.Size = new System.Drawing.Size(42, 13);
            this.lblInclude.TabIndex = 13;
            this.lblInclude.Text = "Include";
            // 
            // lblFamilyCategory
            // 
            this.lblFamilyCategory.AutoSize = true;
            this.lblFamilyCategory.Location = new System.Drawing.Point(11, 15);
            this.lblFamilyCategory.Name = "lblFamilyCategory";
            this.lblFamilyCategory.Size = new System.Drawing.Size(81, 13);
            this.lblFamilyCategory.TabIndex = 14;
            this.lblFamilyCategory.Text = "Family Category";
            // 
            // chklstboxInclude
            // 
            this.chklstboxInclude.FormattingEnabled = true;
            this.chklstboxInclude.Items.AddRange(new object[] {
            "Level Name",
            "Level Number",
            "Position X",
            "Position Y",
            "Position Z"});
            this.chklstboxInclude.Location = new System.Drawing.Point(224, 39);
            this.chklstboxInclude.Name = "chklstboxInclude";
            this.chklstboxInclude.Size = new System.Drawing.Size(147, 124);
            this.chklstboxInclude.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(215, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // autoNumberFormBindingSource
            // 
            this.autoNumberFormBindingSource.DataSource = typeof(AutoNumber.autoNumberForm);
            // 
            // autoNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 218);
            this.Controls.Add(this.updwnIncrement);
            this.Controls.Add(this.updwnStartValue);
            this.Controls.Add(this.cboParameter);
            this.Controls.Add(this.cboDirection);
            this.Controls.Add(this.cboNumberingType);
            this.Controls.Add(this.cboFamilyCategory);
            this.Controls.Add(this.lblNumberingType);
            this.Controls.Add(this.lblParameter);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblIncrement);
            this.Controls.Add(this.lblStartValue);
            this.Controls.Add(this.lblInclude);
            this.Controls.Add(this.lblFamilyCategory);
            this.Controls.Add(this.chklstboxInclude);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "autoNumberForm";
            this.Text = "autoNumberForm";
            this.Load += new System.EventHandler(this.autoNumberForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updwnIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updwnStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoNumberFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown updwnIncrement;
        private System.Windows.Forms.NumericUpDown updwnStartValue;
        private System.Windows.Forms.ComboBox cboParameter;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.ComboBox cboNumberingType;
        private System.Windows.Forms.ComboBox cboFamilyCategory;
        private System.Windows.Forms.Label lblNumberingType;
        private System.Windows.Forms.Label lblParameter;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblIncrement;
        private System.Windows.Forms.Label lblStartValue;
        private System.Windows.Forms.Label lblInclude;
        private System.Windows.Forms.Label lblFamilyCategory;
        private System.Windows.Forms.CheckedListBox chklstboxInclude;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource autoNumberFormBindingSource;
    }
}