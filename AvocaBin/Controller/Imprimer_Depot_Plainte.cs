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
using CrystalDecisions.Shared;

namespace AvocaBin.Controller
{
    public partial class Imprimer_Depot_Plainte : Form
    {
        int id;
        public Imprimer_Depot_Plainte(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Imprimer_Depot_Plainte_Load(object sender, EventArgs e)
        {
            rep_depot_plainte cr = new rep_depot_plainte();
            SqlConnection cn = connection.getConnection();
            PrintAllDepotPlaintDataSet4 ds = new PrintAllDepotPlaintDataSet4();
            String query1 = "select dc.id_depot,dc.id_plainte,cc.nom,ad.nom as[nom_adv],dc.num_check,dc.montant from depot_plgn dc,plaignant cc,par_plaignant ad where dc.id_depot like '" + id + "' and dc.id_par_plaignant=ad.id_par_plaignant and dc.id_plaignant=cc.id_plaignant";
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
