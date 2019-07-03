using AvocaBin.Controller;
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
using System.Data;

namespace AvocaBin
{
    public partial class PrintAllPlaintes : Form
    {
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;
        String id_plainte;
        public PrintAllPlaintes()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void PrintAllPlaintes_Load(object sender, EventArgs e)
        {
            try
            {
                PrintAllPlainteCrystalReport1 c = new PrintAllPlainteCrystalReport1();
                PrintAllPlaintDataSet ds = new PrintAllPlaintDataSet();
                SqlConnection cn = connection.getConnection();
                string query = "select p.*,pl.nom from plaignant pl,plainte p where p.id_plaignant=pl.id_plaignant and p.etat='non archivé'";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.Fill(ds, "plainte");

                string query1 = "select top(1) * from avocat";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, cn);
                da1.Fill(ds, "avocat");

                c.SetDataSource(ds);
                crystalReportViewer1.ReportSource = c;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void reportAllPlaintes1_InitReport(object sender, EventArgs e)
        {

        }
    }
}
