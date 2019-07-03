using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin.Operation;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class impimeAllPlaingnants : Form
    {
        string text;
        PlaintesOperations op;
        SqlConnection cn = connection.getConnection();
        DataSetAllPlaignat ds = new DataSetAllPlaignat();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataAdapter da;
        SqlDataAdapter da1;
        public impimeAllPlaingnants(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void impimeAllPlaingnants_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM plaignant where id_plaignant like @x or cin like @z or nom like @k", cn);
            cmd.Parameters.Add("@x", "%" + text + "%");
            cmd.Parameters.Add("@z", "%" + text + "%");
            cmd.Parameters.Add("@k", "%" + text + "%");
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Plaignant");
           
            cmd1 = new SqlCommand("select top(1)*from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");

                repAllPlaignant i = new repAllPlaignant();
                i.SetDataSource(ds);
                crystalReportViewer1.ReportSource = i;
           
            cn.Close();
            
        }
    }
}
