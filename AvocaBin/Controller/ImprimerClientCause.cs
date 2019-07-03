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
    public partial class ImprimerClientCause : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        datasate_adv ds = new datasate_adv();
        SqlConnection cn = connection.getConnection();
        int id;
        string type;
        
        public ImprimerClientCause(int id,string type)
        {
            this.id = id;
            this.type=type;
            InitializeComponent();
        }

        private void ImprimerClientCause_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }


            cmd = new SqlCommand("Select [id_client_cause] as[مرجع],[type_client] as[النوع],[cin] as[ر.ب.و],[nom] as[الاسم],[representant_legal] as[الممثل التجاري],[registre_commerce] as[السجل التجاري],[adresse] as[العنوان] from client_cause where [id_client_cause] like '"+id+"%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "client");
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");

            if (type=="معنوي")
            {
                    reportClientCause i = new reportClientCause();
                    i.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = i;
            }
            if (type == "طبيعي")
            {
                reportClientCause1 i = new reportClientCause1();
                i.SetDataSource(ds);
                crystalReportViewer1.ReportSource = i;
            }
            cn.Close();

            
        }

        public CrystalDecisions.Shared.ExportOptions ExportOptions { get; set; }

        internal void Export()
        {
            throw new NotImplementedException();
        }
    }
}
