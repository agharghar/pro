namespace AvocaBin
{
    partial class PrintAllCorrectionForm
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
            this.crystalReportViewerCorrection = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerCorrection
            // 
            this.crystalReportViewerCorrection.ActiveViewIndex = -1;
            this.crystalReportViewerCorrection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerCorrection.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerCorrection.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerCorrection.Name = "crystalReportViewerCorrection";
            this.crystalReportViewerCorrection.Size = new System.Drawing.Size(762, 367);
            this.crystalReportViewerCorrection.TabIndex = 0;
            // 
            // PrintAllCorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 367);
            this.Controls.Add(this.crystalReportViewerCorrection);
            this.Name = "PrintAllCorrectionForm";
            this.Text = "PrintAllCorrectionForm";
            this.Load += new System.EventHandler(this.PrintAllCorrectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerCorrection;
    }
}