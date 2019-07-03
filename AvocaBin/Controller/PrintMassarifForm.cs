using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class PrintMassarifForm : Form
    {
        public PrintMassarifForm()
        {
            InitializeComponent();
        }
        public string idPaiement { get; set; }

        private void PrintMassarifForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintMassarifDataSet ds = new PrintMassarifDataSet();

            string q1 = "select * from Paiement where id_paiement='"+idPaiement+"'";
            SqlDataAdapter da = new SqlDataAdapter(q1, cn);
            da.Fill(ds, "paiement");

            string q2 = "select top(1) * from avocat";
            SqlDataAdapter d1 = new SqlDataAdapter(q2, cn);
            d1.Fill(ds, "avocat");

            PrintMassarifCrystalReport cr = new PrintMassarifCrystalReport();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();

        }
    }
}
