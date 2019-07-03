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
    public partial class ImprimerAllAdv : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        datasate_adv ds = new datasate_adv();
        SqlConnection cn = connection.getConnection();
        string id;
        public ImprimerAllAdv(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ImprimerAllAdv_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("Select [id_adversaire_cause] as[مرجع ],[type_adv] as[النوع],[cin_adv] as[ر.ب.و],[nom_adv] as[الاسم],[adjoint_adv] as[نائب الخصم],[representant_legal_adv] as[الممثل التجاري],[registre_commerce_adv] as[السجل التجاري],[adresse_adv] as[العنوان] from adversaire_cause where  cin_adv like'" + id + "%' or registre_commerce_adv like'" + id + "%' or nom_adv like'" + id + "%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "adversaire");
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");
            reportAllAdv_Cause i = new reportAllAdv_Cause();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            cn.Close();

           // reportAllAdv_Cause cr = new reportAllAdv_Cause();
           // crystalReportViewer1.ReportSource = cr;
           // crystalReportViewer1.Refresh();

           // strServer = Properties.Settings.Default.Server;
           // strDatabase = Properties.Settings.Default.DataBase;
           // strUserID = Properties.Settings.Default.ID;
           // strPwd = Properties.Settings.Default.PassWord;
           // cr.DataSourceConnections[0].IntegratedSecurity = false;
           // cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUserID, strPwd);
           //// cr.SetParameterValue("id", id);
           // crystalReportViewer1.ReportSource = cr;
           // crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
