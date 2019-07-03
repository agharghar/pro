namespace AvocaBin
{
    partial class PrintAllNotificationsForm
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
            this.crystalReportViewerAllNotifi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerAllNotifi
            // 
            this.crystalReportViewerAllNotifi.ActiveViewIndex = -1;
            this.crystalReportViewerAllNotifi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerAllNotifi.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerAllNotifi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerAllNotifi.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerAllNotifi.Name = "crystalReportViewerAllNotifi";
            this.crystalReportViewerAllNotifi.Size = new System.Drawing.Size(774, 323);
            this.crystalReportViewerAllNotifi.TabIndex = 0;
            this.crystalReportViewerAllNotifi.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PrintAllNotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 323);
            this.Controls.Add(this.crystalReportViewerAllNotifi);
            this.Name = "PrintAllNotificationsForm";
            this.Text = "PrintAllNotificationsForm";
            this.Load += new System.EventHandler(this.PrintAllNotificationsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerAllNotifi;
    }
}