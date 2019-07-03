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
    public partial class PrintOneOrderForm : Form
    {

        public string idOrder { get; set; }
        public int idcli { get; set; }
        public int idadv { get; set; }

        public PrintOneOrderForm()
        {
            InitializeComponent();
        }

        private void PrintOneOrderForm_Load(object sender, EventArgs e)
        {
            DataSet2 ds = new DataSet2();
            PrintOneOrderCrystalReport cr = new PrintOneOrderCrystalReport();
            SqlConnection cn = connection.getConnection();
            String query1 = "select o.id_order,o.signe_order,o.date_order,o.commissaire_judiciaire,o.ville,o.tribunal,o.decision,o.type from orderr o where o.id_order = '" + idOrder+"'";
            SqlDataAdapter da = new SqlDataAdapter(query1, cn);
            da.Fill(ds, "order");

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            string query3 = "select * from client_order where id_client_order=" + idcli.ToString();
            SqlDataAdapter da3 = new SqlDataAdapter(query3, cn);
            da3.Fill(ds, "client_order");

            string query4 = "select * from adv_order where id_adv_order=" + idadv.ToString();
            SqlDataAdapter da4 = new SqlDataAdapter(query4, cn);
            da4.Fill(ds, "adv_order");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
