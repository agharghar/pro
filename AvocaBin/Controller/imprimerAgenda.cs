using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class imprimerAgenda : Form
    {
        
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        string date1, date2,id;
        int etat;
        اليومية frm = new اليومية();
        DataSet3 ds = new DataSet3();
        public imprimerAgenda(int etat,string date1,string date2,string id)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.etat = etat;
            this.id = id;
            InitializeComponent();
        }

        private void imprimerAgenda_Load(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ds.Clear();
          
            if (cn.State == ConnectionState.Closed) 
            {
                cn.Open(); 
            }
            if (etat == 0)
            {
                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (c.id_cause like'" + id + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.type_cause like'" + id + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.tribunal like'" + id + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv)  order by c.tribunal", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds,"Agenda");
                cmd1 = new SqlCommand("select top(1)*from avocat", cn);
                da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds,"avocat");
            }
            else
            {

                if (etat==-1 && date1==null && date2==null)
                {
                    cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة]  from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds,"Agenda");
                    cmd1 = new SqlCommand("select top(1)*from avocat", cn);
                    da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(ds, "avocat");
                }
                else
                {
                    cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (s.date_session between'" + date1 + "' and '" + date2 + "') and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv  order by c.tribunal", cn);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds,"Agenda");
                    cmd1 = new SqlCommand("select top(1)*from avocat", cn);
                    da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(ds, "avocat");
                }
            
            
            }

            repAgen i = new repAgen();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            i.Refresh();
            cn.Close();


        }
    }
}
