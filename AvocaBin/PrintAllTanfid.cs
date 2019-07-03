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
using AvocaBin;

namespace AvocaBin.Controller
{
    public partial class PrintAllTanfid : Form
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

      //  datasate_adv ds = new datasate_adv();
        //DataAllTanfid data = new DataAllTanfid();
        SqlConnection cn = connection.getConnection();
        string  text;
        
        public PrintAllTanfid(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void PrintAllTanfid_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            //cmd = new SqlCommand("select top(1)*from avocat", cn);
            //da = new SqlDataAdapter(cmd);
            //da.Fill(data, "avocat");

            if (text == "")
            {
               
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                //cmd = new SqlCommand("select t.nomClient as[الموكل], t.idCause as[رقم القضية],n.typeCause as[نوعها],t.tribunal as[المحكمة],t.ville as [المدينة],t.num_notif as[رقم التبليغ],t.num_tanfid as[رقم التنفيد],t.nomAdv as[المنفد عليه],t.date_tanfide as[تاريخ التنفيد],t.type_tanfid as[نوع التنفيد],t.commisaireJudiciaire as[المفوض القضائي],t.note as[الملاحظة] from tanfid t,notification n where t.num_notif=n.id", cn);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(data, "tanfid");
                //data.Tables["table"].Rows.Clear();
                //dataGridView1.DataSource = ds.Tables["table"];

              

            }
            else
            {
               
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select t.nomClient as[الموكل], t.idCause as[رقم القضية],n.typeCause as[نوعها],t.tribunal as[المحكمة],t.ville as [المدينة],t.num_notif as[رقم التبليغ],t.num_tanfid as[رقم التنفيد],t.nomAdv as[المنفد عليه],t.date_tanfide as[تاريخ التنفيد],t.type_tanfid as[نوع التنفيد],t.commisaireJudiciaire as[المفوض القضائي],t.note as[الملاحظة] from tanfid t,notification n where t.num_notif=n.id and (t.nomClient like '%" + text + "%' or t.idCause like '%" + text + "%' or t.num_tanfid like '%" + text + "%')", cn);
                da = new SqlDataAdapter(cmd);
                //da.Fill(ds, "tanfid");
             
            }



            //RepPrintAllTanfid o = new RepPrintAllTanfid();
            //o.SetDataSource(data);
            //crystalReportViewer1.ReportSource = o;
            //cn.Close();
        }
    }
}
