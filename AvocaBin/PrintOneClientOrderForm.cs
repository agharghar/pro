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
    public partial class PrintOneClientOrderForm : Form
    {
        public PrintOneClientOrderForm()
        {
            InitializeComponent();
        }

        public string idClientOrder { get; set; }

        private void PrintOneClientOrderForm_Load(object sender, EventArgs e)
        {
            PrintOneOrderClientDataSet ds = new PrintOneOrderClientDataSet();
            SqlConnection cn = connection.getConnection();
            PrintOneClientOrderCrystalReport cr = new PrintOneClientOrderCrystalReport();

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            string query3 = "select * from client_order where id_client_order=" + idClientOrder.ToString();
            SqlDataAdapter da3 = new SqlDataAdapter(query3, cn);
            da3.Fill(ds, "client_order");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
