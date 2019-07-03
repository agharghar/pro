namespace AvocaBin.Report
{
    partial class ImprimerOnePieceJointDepotCause
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
            this.crystalReportViewerOneCause = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerOneCause
            // 
            this.crystalReportViewerOneCause.ActiveViewIndex = -1;
            this.crystalReportViewerOneCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerOneCause.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerOneCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerOneCause.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerOneCause.Name = "crystalReportViewerOneCause";
            this.crystalReportViewerOneCause.Size = new System.Drawing.Size(763, 298);
            this.crystalReportViewerOneCause.TabIndex = 0;
            // 
            // ImprimerOnePieceJointDepotCause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 298);
            this.Controls.Add(this.crystalReportViewerOneCause);
            this.Name = "ImprimerOnePieceJointDepotCause";
            this.Text = "ImprimerOnePieceJointDepotCause";
            this.Load += new System.EventHandler(this.ImprimerOnePieceJointDepotCause_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerOneCause;
    }
}