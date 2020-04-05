namespace DamageParser
{
    partial class FightOverlay
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
            this.overlayFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // overlayFlowLayoutPanel
            // 
            this.overlayFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlayFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.overlayFlowLayoutPanel.Name = "overlayFlowLayoutPanel";
            this.overlayFlowLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.overlayFlowLayoutPanel.TabIndex = 0;
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.overlayFlowLayoutPanel);
            this.Name = "Overlay";
            this.Text = "Overlay";
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel overlayFlowLayoutPanel;
    }
}