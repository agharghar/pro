namespace AvocaBin.Report
{
    partial class ImprimerOnePieceJointDepotPlgnt
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
            this.crystalReportViewerPlgnt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerPlgnt
            // 
            this.crystalReportViewerPlgnt.ActiveViewIndex = -1;
            this.crystalReportViewerPlgnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerPlgnt.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerPlgnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerPlgnt.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerPlgnt.Name = "crystalReportViewerPlgnt";
            this.crystalReportViewerPlgnt.Size = new System.Drawing.Size(720, 323);
            this.crystalReportViewerPlgnt.TabIndex = 0;
            this.crystalReportViewerPlgnt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImprimerOnePieceJointDepotPlgnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 323);
            this.Controls.Add(this.crystalReportViewerPlgnt);
            this.Name = "ImprimerOnePieceJointDepotPlgnt";
            this.Text = "ImprimerOnePieceJointDepotPlgnt";
            this.Load += new System.EventHandler(this.ImprimerOnePieceJointDepotPlgnt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerPlgnt;

    }
}