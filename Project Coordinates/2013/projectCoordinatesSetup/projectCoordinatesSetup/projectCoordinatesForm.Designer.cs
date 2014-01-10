//
// (C) Copyright 2003-2012 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE. AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//   

namespace projectCoordinatesSetup
{
    /// <summary>
    /// coordinate system data form
    /// </summary>
    partial class projectCoordinatesForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.northingTextBox = new System.Windows.Forms.TextBox();
            this.eastingTextBox = new System.Windows.Forms.TextBox();
            this.trueNorthTextBox = new System.Windows.Forms.TextBox();
            this.elevationTextBox = new System.Windows.Forms.TextBox();
            this.locationListBox = new System.Windows.Forms.ListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.projectLocationsLabel = new System.Windows.Forms.Label();
            this.trueNorthComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "First Storey FFL : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Angle From True North :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Northing Value : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Easting Value : ";
            // 
            // northingTextBox
            // 
            this.northingTextBox.Location = new System.Drawing.Point(138, 87);
            this.northingTextBox.Name = "northingTextBox";
            this.northingTextBox.Size = new System.Drawing.Size(96, 20);
            this.northingTextBox.TabIndex = 8;
            // 
            // eastingTextBox
            // 
            this.eastingTextBox.Location = new System.Drawing.Point(138, 113);
            this.eastingTextBox.Name = "eastingTextBox";
            this.eastingTextBox.Size = new System.Drawing.Size(96, 20);
            this.eastingTextBox.TabIndex = 9;
            // 
            // trueNorthTextBox
            // 
            this.trueNorthTextBox.Location = new System.Drawing.Point(138, 165);
            this.trueNorthTextBox.Name = "trueNorthTextBox";
            this.trueNorthTextBox.Size = new System.Drawing.Size(96, 20);
            this.trueNorthTextBox.TabIndex = 13;
            this.trueNorthTextBox.Leave += new System.EventHandler(this.trueNorthTextBox_Leave);
            // 
            // elevationTextBox
            // 
            this.elevationTextBox.Location = new System.Drawing.Point(138, 139);
            this.elevationTextBox.Name = "elevationTextBox";
            this.elevationTextBox.Size = new System.Drawing.Size(96, 20);
            this.elevationTextBox.TabIndex = 12;
            // 
            // locationListBox
            // 
            this.locationListBox.FormattingEnabled = true;
            this.locationListBox.Location = new System.Drawing.Point(12, 28);
            this.locationListBox.Name = "locationListBox";
            this.locationListBox.Size = new System.Drawing.Size(222, 43);
            this.locationListBox.Sorted = true;
            this.locationListBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(27, 218);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(90, 25);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(123, 218);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 25);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // projectLocationsLabel
            // 
            this.projectLocationsLabel.AutoSize = true;
            this.projectLocationsLabel.Location = new System.Drawing.Point(12, 9);
            this.projectLocationsLabel.Name = "projectLocationsLabel";
            this.projectLocationsLabel.Size = new System.Drawing.Size(89, 13);
            this.projectLocationsLabel.TabIndex = 16;
            this.projectLocationsLabel.Text = "Project Locations";
            // 
            // trueNorthComboBox
            // 
            this.trueNorthComboBox.FormattingEnabled = true;
            this.trueNorthComboBox.Items.AddRange(new object[] {
            "Clockwise",
            "Anti-Clockwise"});
            this.trueNorthComboBox.Location = new System.Drawing.Point(138, 191);
            this.trueNorthComboBox.Name = "trueNorthComboBox";
            this.trueNorthComboBox.Size = new System.Drawing.Size(96, 21);
            this.trueNorthComboBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rotation :";
            // 
            // CoordinateSystemDataForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(248, 258);
            this.Controls.Add(this.trueNorthComboBox);
            this.Controls.Add(this.projectLocationsLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.northingTextBox);
            this.Controls.Add(this.eastingTextBox);
            this.Controls.Add(this.locationListBox);
            this.Controls.Add(this.trueNorthTextBox);
            this.Controls.Add(this.elevationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoordinateSystemDataForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Coordinates Set up";
            this.Load += new System.EventHandler(this.projectCoordinatesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox locationListBox;
        private System.Windows.Forms.TextBox northingTextBox;
        private System.Windows.Forms.TextBox eastingTextBox;
        private System.Windows.Forms.TextBox trueNorthTextBox;
        private System.Windows.Forms.TextBox elevationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label projectLocationsLabel;
        private System.Windows.Forms.ComboBox trueNorthComboBox;
        private System.Windows.Forms.Label label5;
    }
}
