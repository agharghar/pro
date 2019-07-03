using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin.Controller;
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class Imprimer_depot_order : Form
    {
        int id;
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;
        public Imprimer_depot_order(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Imprimer_depot_order_Load(object sender, EventArgs e)
        {
            rep_depot_order cr = new rep_depot_order();
            SqlConnection cn = connection.getConnection();
            PrintAllDepotOrderDataSet4 ds = new PrintAllDepotOrderDataSet4();

            string query1 = "select do.id_depot,do.id_order,co.nom,ao.nom as[nom_adv],do.num_check,do.montant from depot_order do,client_order co ,adv_order ao where do.id_depot like '"+id+"' and co.id_client_order=do.id_client_order and ao.id_adv_order=do.id_adv_order";
            SqlDataAdapter da = new SqlDataAdapter(query1, cn);
            da.Fill(ds, "Commande");

            string query2 = "select top(1) * from avocat";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, cn);
            da2.Fill(ds, "avocat");

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
