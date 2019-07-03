using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin.Report;

namespace AvocaBin
{
    public partial class PrintOneCorrectionForm : Form
    {
        public string id { get; set; }
        public PrintOneCorrectionForm()
        {
            InitializeComponent();
        }

        private void PrintOneCorrectionForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintOneCorrectionCrystalReport cr = new PrintOneCorrectionCrystalReport();
            PrintCorrectionDataSet ds = new PrintCorrectionDataSet();
            String query1 = "select * from coercition_physique where n_coercition_physique="+id;
            SqlDataAdapter da = new SqlDataAdapter(query1, cn);
            da.Fill(ds, "coercition_physique");

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
