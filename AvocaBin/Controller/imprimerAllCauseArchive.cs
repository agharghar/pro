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

namespace AvocaBin.Controller
{
    public partial class imprimerAllCauseArchive : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        datasate_adv ds = new datasate_adv();
        SqlConnection cn = connection.getConnection();
        //string id;
        string id;
        public imprimerAllCauseArchive(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void imprimerAllCauseArchive_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("select c.id_cause,cl.nom ,ad.nom_adv,c.num_cause_tribunal ,c.type_cause ,c.ville,c.tribunal  from cause c,client_cause cl,adversaire_cause ad where( c.id_cause like '%" + id + "%' and c.etat='archivé'  and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( c.num_cause_tribunal like '%" + id + "%' and  c.etat='archivé'  and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.nom like '%" + id + "%' and c.etat='archivé'  and  c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.cin like '%" + id + "%' and c.etat='archivé'  and  c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause)order by date_session ASC", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "cause");
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");
            allCauseArchive i = new allCauseArchive();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            cn.Close();
        }
    }
}
