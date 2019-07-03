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

namespace AvocaBin.Controller
{
    public partial class Imprimer_Depot_Cause : Form
    {
        int id;
       
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;
        public Imprimer_Depot_Cause(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Imprimer_Depot_Cause_Load(object sender, EventArgs e)
        {
            rep_depot_cause cr = new rep_depot_cause();
            //cr.SetParameterValue("id", id);
            //crystalReportViewer1.ReportSource = cr;
            //crystalReportViewer1.Refresh();

            SqlConnection cn = connection.getConnection();
            PrintAllDepotCauseDataSet4 ds = new PrintAllDepotCauseDataSet4();
            String query1 = "select dp.id_depot,dp.id_cause,cc.nom,ad.nom_adv,dp.num_check,dp.montant from depot_cause dp,adversaire_cause ad,client_cause cc where dp.id_depot like '" + id + "' and cc.id_client_cause=dp.id_client_cause and dp.id_adversaire_cause=ad.id_adversaire_cause";
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
