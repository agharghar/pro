using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class PrintAllCorrectionForm : Form
    {
        public PrintAllCorrectionForm()
        {
            InitializeComponent();
        }

        private void PrintAllCorrectionForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintCorrectionCrystalReport cr = new PrintCorrectionCrystalReport();
            PrintCorrectionDataSet ds = new PrintCorrectionDataSet();
            String query1 = "select * from coercition_physique";
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
