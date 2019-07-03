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
    public partial class ImprimerAllDepotOrder : Form
    {
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;

        string id;
        public ImprimerAllDepotOrder(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ImprimerAllDepotOrder_Load(object sender, EventArgs e)
        {
            RepAllDepotOrder cr = new RepAllDepotOrder();
            PrintAllDepotOrderDataSet4 ds = new PrintAllDepotOrderDataSet4();
            SqlConnection cn = connection.getConnection();

            String query1 = "select do.id_depot,do.id_order,co.nom,ao.nom as[nom_adv],do.num_check,do.montant from depot_order do,client_order co ,adv_order ao where co.id_client_order=do.id_client_order and ao.id_adv_order=do.id_adv_order";
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
