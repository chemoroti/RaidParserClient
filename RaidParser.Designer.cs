namespace DamageParser
{
    partial class RaidParser
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
            this.fileUploadLabel = new System.Windows.Forms.Label();
            this.logFileUploadDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileUploadButton = new System.Windows.Forms.Button();
            this.displayOverlayCheckBox = new System.Windows.Forms.CheckBox();
            this.setOverlayPositionButton = new System.Windows.Forms.Button();
            this.raidIdTextBox = new System.Windows.Forms.TextBox();
            this.raidIdLabel = new System.Windows.Forms.Label();
            this.updateRaidIdButton = new System.Windows.Forms.Button();
            this.resetOverlayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileUploadLabel
            // 
            this.fileUploadLabel.AutoSize = true;
            this.fileUploadLabel.Location = new System.Drawing.Point(13, 13);
            this.fileUploadLabel.Name = "fileUploadLabel";
            this.fileUploadLabel.Size = new System.Drawing.Size(78, 13);
            this.fileUploadLabel.TabIndex = 0;
            this.fileUploadLabel.Text = "Select Log FIle";
            // 
            // logFileUploadDialog
            // 
            this.logFileUploadDialog.FileName = "openFileDialog1";
            // 
            // fileUploadButton
            // 
            this.fileUploadButton.Location = new System.Drawing.Point(16, 30);
            this.fileUploadButton.Name = "fileUploadButton";
            this.fileUploadButton.Size = new System.Drawing.Size(75, 23);
            this.fileUploadButton.TabIndex = 1;
            this.fileUploadButton.Text = "Log FIle";
            this.fileUploadButton.UseVisualStyleBackColor = true;
            this.fileUploadButton.Click += new System.EventHandler(this.FileUploadButton_Click);
            // 
            // displayOverlayCheckBox
            // 
            this.displayOverlayCheckBox.AutoSize = true;
            this.displayOverlayCheckBox.Checked = true;
            this.displayOverlayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayOverlayCheckBox.Location = new System.Drawing.Point(16, 88);
            this.displayOverlayCheckBox.Name = "displayOverlayCheckBox";
            this.displayOverlayCheckBox.Size = new System.Drawing.Size(99, 17);
            this.displayOverlayCheckBox.TabIndex = 2;
            this.displayOverlayCheckBox.Text = "Display Overlay";
            this.displayOverlayCheckBox.UseVisualStyleBackColor = true;
            this.displayOverlayCheckBox.CheckedChanged += new System.EventHandler(this.DisplayOverlayCheckBox_CheckedChanged);
            // 
            // setOverlayPositionButton
            // 
            this.setOverlayPositionButton.Location = new System.Drawing.Point(16, 112);
            this.setOverlayPositionButton.Name = "setOverlayPositionButton";
            this.setOverlayPositionButton.Size = new System.Drawing.Size(133, 23);
            this.setOverlayPositionButton.TabIndex = 3;
            this.setOverlayPositionButton.Text = "Update Position";
            this.setOverlayPositionButton.UseVisualStyleBackColor = true;
            this.setOverlayPositionButton.Click += new System.EventHandler(this.SetOverlayPositionButton_Click);
            // 
            // raidIdTextBox
            // 
            this.raidIdTextBox.Location = new System.Drawing.Point(16, 183);
            this.raidIdTextBox.Name = "raidIdTextBox";
            this.raidIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.raidIdTextBox.TabIndex = 4;
            this.raidIdTextBox.TextChanged += new System.EventHandler(this.RaidIdTextBox_TextChanged);
            // 
            // raidIdLabel
            // 
            this.raidIdLabel.AutoSize = true;
            this.raidIdLabel.Location = new System.Drawing.Point(16, 164);
            this.raidIdLabel.Name = "raidIdLabel";
            this.raidIdLabel.Size = new System.Drawing.Size(43, 13);
            this.raidIdLabel.TabIndex = 5;
            this.raidIdLabel.Text = "Raid ID";
            // 
            // updateRaidIdButton
            // 
            this.updateRaidIdButton.Location = new System.Drawing.Point(16, 210);
            this.updateRaidIdButton.Name = "updateRaidIdButton";
            this.updateRaidIdButton.Size = new System.Drawing.Size(75, 23);
            this.updateRaidIdButton.TabIndex = 6;
            this.updateRaidIdButton.Text = "Save";
            this.updateRaidIdButton.UseVisualStyleBackColor = true;
            this.updateRaidIdButton.Click += new System.EventHandler(this.UpdateRaidIdButton_Click);
            // 
            // resetOverlayButton
            // 
            this.resetOverlayButton.Location = new System.Drawing.Point(156, 111);
            this.resetOverlayButton.Name = "resetOverlayButton";
            this.resetOverlayButton.Size = new System.Drawing.Size(92, 23);
            this.resetOverlayButton.TabIndex = 7;
            this.resetOverlayButton.Text = "Reset Position";
            this.resetOverlayButton.UseVisualStyleBackColor = true;
            this.resetOverlayButton.Click += new System.EventHandler(this.ResetOverlayButton_Click);
            // 
            // RaidParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 249);
            this.Controls.Add(this.resetOverlayButton);
            this.Controls.Add(this.updateRaidIdButton);
            this.Controls.Add(this.raidIdLabel);
            this.Controls.Add(this.raidIdTextBox);
            this.Controls.Add(this.setOverlayPositionButton);
            this.Controls.Add(this.displayOverlayCheckBox);
            this.Controls.Add(this.fileUploadButton);
            this.Controls.Add(this.fileUploadLabel);
            this.Name = "RaidParser";
            this.Text = "TAKP Raid Parser";
            this.Load += new System.EventHandler(this.RaidParser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileUploadLabel;
        private System.Windows.Forms.OpenFileDialog logFileUploadDialog;
        private System.Windows.Forms.Button fileUploadButton;
        private System.Windows.Forms.CheckBox displayOverlayCheckBox;
        private System.Windows.Forms.Button setOverlayPositionButton;
        private System.Windows.Forms.TextBox raidIdTextBox;
        private System.Windows.Forms.Label raidIdLabel;
        private System.Windows.Forms.Button updateRaidIdButton;
        private System.Windows.Forms.Button resetOverlayButton;
    }
}

