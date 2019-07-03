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
using AvocaBin.Controller;

namespace AvocaBin
{
    public partial class PrintOneTanfid : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        
        //SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        SqlDataAdapter da2 = new SqlDataAdapter();
        SqlDataAdapter da3 = new SqlDataAdapter();
        SqlDataAdapter da4 = new SqlDataAdapter();
        
        //datasate_adv ds = new datasate_adv();
        //DataTanfid ds = new DataTanfid();
        SqlConnection cn = connection.getConnection();
        string typeFil, numTanfid;

        public PrintOneTanfid(string typeFil, string numTanfid)
        {
            this.typeFil = typeFil;
            this.numTanfid = numTanfid;
            InitializeComponent();
        }

        private void PrintOneTanfid_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd = new SqlCommand("select top(1)*from avocat", cn);
            da = new SqlDataAdapter(cmd);
            //da.Fill(ds, "avocat");

            cmd1 = new SqlCommand("select num_tanfid as[رقم التنفيد],t.commisaireJudiciaire as[المفوض القضائي],type_tanfid as[نوع التنفيد],n.DecisionFinal as[الحكم] from tanfid t,notification n where t.num_notif=n.id and t.num_tanfid='"+numTanfid+"'", cn);
            da1 = new SqlDataAdapter(cmd1);
            //da1.Fill(ds, "tanfid");

            if (typeFil=="الموضوع")
            {
                cmd2 = new SqlCommand("select c.id_cause as [مرجع القضية],c.num_cause_tribunal as[رقم القضية بالمحكمة],c.tribunal as[المحكمة],c.juge as[القاضي],c.ville as[المدينة] from cause c where c.id_cause=(select t.idCause  from tanfid t where t.num_tanfid='" + numTanfid + "')", cn);
                da2 = new SqlDataAdapter(cmd2);
                //da2.Fill(ds, "cause");

                cmd3 = new SqlCommand("select nom as[الاسم],cin as[رقم البطاقة الوطنية],type_client as[نوع الموكل],telephone as[الهاتف],adresse as[العنوان] from client_cause where id_client_cause =(select idClient from notification where id=(select num_notif from tanfid where num_tanfid='"+numTanfid+"'))", cn);
                da3 = new SqlDataAdapter(cmd3);
                //da3.Fill(ds, "client");

               // MessageBox.Show(ds.Tables["client"].Rows[0][1].ToString());

                cmd4 = new SqlCommand("select nom_adv as[الاسم],cin_adv as[رقم البطاقة الوطنية],type_adv as[نوع الخصم],adresse_adv as[العنوان] from adversaire_cause where id_adversaire_cause =(select idAdv from notification where id=(select num_notif from tanfid where num_tanfid='" + numTanfid + "'))", cn);
                da4 = new SqlDataAdapter(cmd4);
                //da4.Fill(ds, "adv");

                repTanfid i = new repTanfid();
                //i.SetDataSource(ds);
                crystalReportViewer1.ReportSource = i;
            }
            if (typeFil == "الامر")
            {
                cmd2 = new SqlCommand("select c.id_order as [مرجع الامر],c.type as[نوع الامر],c.tribunal as[المحكمة],c.ville as[المدينة] from orderr c where c.id_order=(select t.idCause  from tanfid t where t.num_tanfid='"+numTanfid+"')", cn);
                da2 = new SqlDataAdapter(cmd2);
                //da2.Fill(ds, "cause");

                cmd3 = new SqlCommand("select nom as[الاسم],cin as[رقم البطاقة الوطنية],type_client_order as[نوع الموكل],telephone as[الهاتف],adresse as[العنوان] from client_order where id_client_order =(select idClient from notification where id=(select num_notif from tanfid where num_tanfid='"+numTanfid+"'))", cn);
                da3 = new SqlDataAdapter(cmd3);
                //da3.Fill(ds, "client");

                cmd4 = new SqlCommand("select nom as[الاسم],cin as[رقم البطاقة الوطنية],type_adv_order as[نوع الخصم],adresse as[العنوان] from adv_order where id_adv_order =(select idAdv from notification where id=(select num_notif from tanfid where num_tanfid='"+numTanfid+"'))", cn);
                da4 = new SqlDataAdapter(cmd4);
                //da4.Fill(ds, "adv");

                
                //PrintOneTanfidOrder o = new PrintOneTanfidOrder();
                //o.SetDataSource(ds);
                //crystalReportViewer1.ReportSource = o;
            }




            
            cn.Close();
        }
    }
}
