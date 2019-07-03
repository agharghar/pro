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
using AvocaBin.DateSet;
namespace AvocaBin
{
    public partial class PrintAllNotificationsForm : Form
    {
        public PrintAllNotificationsForm()
        {
            InitializeComponent();
        }

        private void PrintAllNotificationsForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection();
            PrintNotificationDataSet ds = new PrintNotificationDataSet();
            PrintAllNotificationCrystalReport cr = new PrintAllNotificationCrystalReport();

            string query = "select * from notification";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            da.Fill(ds.Tables["notification"]);

            query = "select top(1) * from avocat";
            SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
            da1.Fill(ds.Tables["avocat"]);

            cr.SetDataSource(ds);
            crystalReportViewerAllNotifi.ReportSource = cr;
            crystalReportViewerAllNotifi.Refresh();
        }
    }
}
