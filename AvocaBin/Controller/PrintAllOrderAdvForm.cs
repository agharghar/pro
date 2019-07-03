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
    public partial class PrintAllOrderAdvForm : Form
    {
        public PrintAllOrderAdvForm()
        {
            InitializeComponent();
        }

        private void PrintAllOrderAdvForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintAllOrderAdvDataSet ds = new PrintAllOrderAdvDataSet();
            PrintAllOrderAdvCrystalReport cr = new PrintAllOrderAdvCrystalReport();

            string query4 = "select * from adv_order";
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
