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
    public partial class ImprimerAllClientCause : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        datasetClient ds = new datasetClient();
        SqlConnection cn = connection.getConnection();
        string id;
        public ImprimerAllClientCause(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ImprimerAllClientCause_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("Select [id_client_cause] as[مرجع],[type_client] as[النوع],[cin] as[ر.ب.و],[nom] as[الاسم],[representant_legal] as[الممثل التجاري],[registre_commerce] as[السجل التجاري],[adresse] as[العنوان] from client_cause where  cin like'" + id + "%' or registre_commerce like'" + id + "%' or nom like'" + id + "%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "client");
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");
            reportAllclientCause i = new reportAllclientCause();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;
            cn.Close();
            //reportAllclientCause cr = new reportAllclientCause();
            ////crystalReportViewer1.ReportSource = cr;
            ////crystalReportViewer1.Refresh();

            //strServer = Properties.Settings.Default.Server;
            //strDatabase = Properties.Settings.Default.DataBase;
            //strUserID = Properties.Settings.Default.ID;
            //strPwd = Properties.Settings.Default.PassWord;
            //cr.DataSourceConnections[0].IntegratedSecurity = false;
            //cr.DataSourceConnections[0].SetConnection(strServer, strDatabase, strUserID, strPwd);
            ////i.SetParameterValue("id_cause", id.Trim());
            //crystalReportViewer1.ReportSource = cr;
            //crystalReportViewer1.Refresh();
            
        }
    }
}
