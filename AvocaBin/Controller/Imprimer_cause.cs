using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class Imprimer_cause : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        SqlDataAdapter da2 = new SqlDataAdapter();
        DataSetCause ds = new DataSetCause();
        SqlConnection cn = connection.getConnection();
        //int id;
       
        string id;
        public Imprimer_cause(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Imprimer_cause_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand(" SELECT adversaire_cause.nom_adv,adversaire_cause.type_adv, adversaire_cause.adresse_adv, adversaire_cause.cin_adv, adversaire_cause.adjoint_adv, cause.tribunal, cause.id_cause, cause.juge, cause.ville, client_cause.nom, client_cause.telephone, client_cause.adresse, client_cause.cin, cause.num_cause_tribunal, client_cause.type_client FROM (DB_Avocabine.dbo.cause cause INNER JOIN DB_Avocabine.dbo.adversaire_cause adversaire_cause ON cause.id_adv=adversaire_cause.id_adversaire_cause) INNER JOIN DB_Avocabine.dbo.client_cause client_cause ON cause.id_client=client_cause.id_client_cause and cause.id_cause like'"+id+"%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "cause");

            cmd1 = new SqlCommand("select top(1) * from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");


            cmd2 = new SqlCommand("select * from sessione where id_cause like'"+id+"%'", cn);
            da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds, "sessione");

            rep_cause i = new rep_cause();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            cn.Close();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
