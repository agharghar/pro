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
    public partial class PrintAllOrdersForm : Form
    {
        public PrintAllOrdersForm()
        {
            InitializeComponent();
        }

        private void PrintAllOrdersForm_Load(object sender, EventArgs e)
        {
            DataSet2 ds = new DataSet2();
            PrintAllOrdersReport cr = new PrintAllOrdersReport();
            SqlConnection cn = connection.getConnection();
            String query1 = "select o.id_order,o.signe_order,o.date_order,o.commissaire_judiciaire,o.ville,o.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',o.decision,o.type from orderr o,adv_order a,client_order c where o.id_adversaire_order=a.id_adv_order and o.id_client_order=c.id_client_order";
            SqlDataAdapter da = new SqlDataAdapter(query1, cn);
            da.Fill(ds, "orderr");

            string query2 = "select nom_avocat,adresse,autorite from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
