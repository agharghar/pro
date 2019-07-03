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
    public partial class imprimerAllPar_Plai : Form
    {
        string text;
        // PlaintesOperations op;
        SqlConnection cn = connection.getConnection();
        DataSet_par_plai ds = new DataSet_par_plai();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        public imprimerAllPar_Plai(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void imprimerAllPar_Plai_Load(object sender, EventArgs e)
        {

            cmd = new SqlCommand("SELECT * FROM par_plaignant where id_par_plaignant like @x or cin like @z or nom like @k", cn);
            cmd.Parameters.Add("@x", "%" + text + "%");
            cmd.Parameters.Add("@z", "%" + text + "%");
            cmd.Parameters.Add("@k", "%" + text + "%");
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "par_plai");

            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "Avocat");

            repAllParPlai i = new repAllParPlai();
            i.SetDataSource(ds);
            crystalReportViewer1.ReportSource = i;

            cn.Close();
        }
    }
}
