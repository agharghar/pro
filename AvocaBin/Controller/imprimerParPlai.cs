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
    public partial class imprimerParPlai : Form
    {
        string text;
       // PlaintesOperations op;
        SqlConnection cn = connection.getConnection();
        DataSet_par_plai ds = new DataSet_par_plai();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        int id;
        public imprimerParPlai(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void imprimerParPlai_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("SELECT * from par_plaignant where id_par_plaignant like'" + id + "%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "par_plai");

            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "Avocat");

            rep_par_plai i = new rep_par_plai();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;

            cn.Close();
            
        }
    }
}
