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
    public partial class imprimer_adv_cause : Form
    {
        //string strServer;
        //string strDatabase;
        //string strUserID;
        //string strPwd;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        //SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        datasate_adv ds = new datasate_adv();
        SqlConnection cn = connection.getConnection();
        int id;
        string type;
        public imprimer_adv_cause(int id,string type)
        {
            this.id = id;
            this.type = type;
            InitializeComponent();
        }

        private void imprimer_adv_cause_Load(object sender, EventArgs e)
        {

               if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("Select [id_adversaire_cause] as[مرجع ],[type_adv] as[النوع],[cin_adv] as[ر.ب.و],[nom_adv] as[الاسم],[adjoint_adv] as[نائب الخصم],[representant_legal_adv] as[الممثل القانوني],[registre_commerce_adv] as[السجل التجاري],[adresse_adv] as[العنوان] from adversaire_cause where id_adversaire_cause like '" + id + "%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "adversaire");
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");

            if (type=="طبيعي")
            {
                repAdv i = new repAdv();
                i.SetDataSource(ds);
                crystalReportViewer1.ReportSource = i;
            }
            if (type == "معنوي")
            {
                repAdv1 i = new repAdv1();
                i.SetDataSource(ds);
                crystalReportViewer1.ReportSource = i;
            }
            
            cn.Close();

            
            
            
        }
    }
}
