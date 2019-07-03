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
using AvocaBin;

namespace AvocaBin
{
    public partial class PrintOneNotificationForm : Form
    {
        public PrintOneNotificationForm()
        {
            InitializeComponent();
        }
        public string id { get; set; }

        private void PrintOneNotificationForm_Load(object sender, EventArgs e)
        {
            SqlConnection cn = connection.getConnection(); 
            PrintOneNotificationDataSet ds = new PrintOneNotificationDataSet();
            PrintOneNotificationCrystalReport cr = new PrintOneNotificationCrystalReport();


            string query = "select * from notification where id='" + id+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            da.Fill(ds.Tables["notification"]);

            string type=ds.Tables["notification"].Rows[0][9].ToString();

            query = "select top(1) * from avocat";
            SqlDataAdapter da1 = new SqlDataAdapter(query, cn);
            da1.Fill(ds.Tables["avocat"]);

            if (type == "موضوع")
            {
                query = "select c.id_cause as 'id',c.type_cause as 'type',c.tribunal as 'tribunal',c.ville as 'ville',c.signe_cause as 'signe' from notification n,cause c where n.id='" + id + "' and n.idCause=c.id_cause";
                SqlDataAdapter da2 = new SqlDataAdapter(query, cn);
                da2.Fill(ds.Tables["file"]);
            }
            else
            {
                query = "select o.id_order as 'id',o.type as 'type',o.tribunal as 'tribunal',o.ville as 'ville',o.signe_order as 'signe' from notification n,orderr o where n.id='" + id + "' and n.idCause=o.id_order";
                SqlDataAdapter da3 = new SqlDataAdapter(query, cn);
                da3.Fill(ds.Tables["file"]);
            }

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
