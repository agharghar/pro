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

namespace AvocaBin.Controller
{
    public partial class ImprimerAllDept_Cause : Form
    {
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;
        string id;

        public ImprimerAllDept_Cause(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ImprimerAllDept_Cause_Load(object sender, EventArgs e)
        {
            repAlldepotCause cr = new repAlldepotCause();
            PrintAllDepotCauseDataSet4 ds = new PrintAllDepotCauseDataSet4();
            SqlConnection cn = connection.getConnection();

            String query1 = "select distinct dp.id_depot,dp.id_cause,cc.nom,ad.nom_adv,dp.num_check,dp.montant from depot_cause dp,adversaire_cause ad,client_cause cc where cc.id_client_cause=dp.id_client_cause and dp.id_adversaire_cause=ad.id_adversaire_cause";
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
