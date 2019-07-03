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
    public partial class imprimer_plaignant : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();

        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();

        DataSet4 ds = new DataSet4();
        SqlConnection cn = connection.getConnection();
        int id;
        public imprimer_plaignant(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        private void imprimer_plaignant_Load(object sender, EventArgs e)
        {
            
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("SELECT id_plaignant as[المرجع], type_plaignant as[نوع المشتكي],cin as[ر.ب.و],nom as[الاسم الكامل],telephone as[الهاتف],representant_legal as[الممثل القانوني],registre_commerce as[السجل التجاري],adresse as[العنوان] from plaignant where id_plaignant like'" + id + "%'", cn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "plaignant");

            cmd1 = new SqlCommand("select top(1) * from avocat", cn);
            da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds, "avocat");

            Report_Plaignant i = new Report_Plaignant();
            i.SetDataSource(ds);

            crystalReportViewer1.ReportSource = i;
            crystalReportViewer1.Refresh();
            cn.Close();
        }
    }
}
