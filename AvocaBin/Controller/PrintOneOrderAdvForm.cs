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
    public partial class PrintOneOrderAdvForm : Form
    {
        public PrintOneOrderAdvForm()
        {
            InitializeComponent();
        }

        public string idAdv { get; set; }

        private void PrintOneOrderAdvForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintOneOrderAdvDataSet ds = new PrintOneOrderAdvDataSet();
            PrintOneOrderAdvCrystalReport cr = new PrintOneOrderAdvCrystalReport();

            string query4 = "select * from adv_order where id_adv_order=" + idAdv;
            SqlDataAdapter da4 = new SqlDataAdapter(query4, cn);
            da4.Fill(ds, "adv_order");

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
