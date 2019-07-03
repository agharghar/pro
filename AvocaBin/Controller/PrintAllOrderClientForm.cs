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
    public partial class PrintAllOrderClientForm : Form
    {
        public PrintAllOrderClientForm()
        {
            InitializeComponent();
        }

        private void PrintAllOrderClientForm_Load(object sender, EventArgs e)
        {
            PrintAllClientOrderDataSet ds = new PrintAllClientOrderDataSet();
            SqlConnection cn = connection.getConnection();
            PrintAllOrderClientCrystalReport cr = new PrintAllOrderClientCrystalReport();

            string query3 = "select * from client_order";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, cn);
            da3.Fill(ds, "client_order");

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
