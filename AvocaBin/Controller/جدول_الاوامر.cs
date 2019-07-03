using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using AvocaBin.Controller;
using AvocaBin.Models;
using AvocaBin.Report;

namespace AvocaBin
{
    public partial class جدول_الاوامر : DevExpress.XtraEditors.XtraForm
    {
        public جدول_الاوامر()
        {
            InitializeComponent();
        }

        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        string id, cin, d1, d2;

        private void refresh()
        {
            SqlDataReader dr;
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select o.id_order,o.signe_order,o.date_order,o.commissaire_judiciaire,o.ville,o.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',o.decision,o.type from orderr o,client_order c,adv_order a where o.etat='non archivé' and o.id_client_order=c.id_client_order and o.id_adversaire_order=a.id_adv_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            cn.Close();
        }

        private void btn_searsh_Click(object sender, EventArgs e)
        {
            
        }
        
        private void جدول_الاوامر_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحدف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    int r = order.delete(id);
                    if (r == 1) { MessageBox.Show("تم الحدف بنجاح"); }
                    else { MessageBox.Show("الرجاء إعادة المحاولة"); }
                    history.AddHistory("الأمر", "حدف", id);
                    refresh();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error : " + ee);
                }
            }
            else
            { }
        }

        private void cb_ville_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //try
            ////{
            //    d1 = date_debut.Value.ToShortDateString();
            //    d2 = date_fin.Value.ToShortDateString();

            //    if (cn.State == ConnectionState.Closed) { cn.Open(); }
            //    DataTable dt = new DataTable();
            //    SqlDataReader dr;
            //    cmd.Connection = cn;
            //    cmd.CommandText = "select distinct ord.id_order,ord.signe_order,ord.date_order,ord.commissaire_judiciaire,ord.ville,ord.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',ord.decision,ord.type from orderr ord,client_order c,adv_order a where ord.id_client_order=a.id_adv_order and ord.id_client_order=c.id_client_order and ord.date_order between '@d1' and '@d2'";
            //    cmd.Parameters.Add("@d1", d1);
            //    cmd.Parameters.Add("@d2", d2);
            //    dr = cmd.ExecuteReader();
            //    dt.Load(dr);
            //    dataGridView1.DataSource = dt;
            //    dr.Close();
            //    cn.Close();
            //    cmd.Parameters.Clear();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PrintAllOrdersForm p = new PrintAllOrdersForm();
            p.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                الأمر f = new الأمر();
                f.txb_num_orderValue = (string)dataGridView1.CurrentRow.Cells[0].Value;
                f.combobox1Value = (string)dataGridView1.CurrentRow.Cells[9].Value;
                f.txtMofawadValue = (string)dataGridView1.CurrentRow.Cells[3].Value;
                f.cbVilleValue = (string)dataGridView1.CurrentRow.Cells[4].Value;
                f.cb_genre_trubinalValue = (string)dataGridView1.CurrentRow.Cells[5].Value;
                f.signeOrderValue = (string)dataGridView1.CurrentRow.Cells[1].Value;
                f.decisionValue = (string)dataGridView1.CurrentRow.Cells[8].Value;
                SqlConnection cn = connection.getConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd.Connection = cn;
                cmd.CommandText = "select id_client_order,id_adversaire_order from orderr where id_order = @id";
                cmd.Parameters.Add("@id", (string)dataGridView1.CurrentRow.Cells[0].Value);
                dr = cmd.ExecuteReader();
                dr.Read();
                int idcl = (int)dr["id_client_order"];
                int idad = (int)dr["id_adversaire_order"];
                dr.Close();
                dr.Dispose();
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from client_order where id_client_order=@id";
                cmd.Parameters.Add("@id", idcl);
                dr = cmd.ExecuteReader();
                dr.Read();
                f.idclient = dr["id_client_order"].ToString();
                f.cbGenreClientValue = (string)dr["type_client_order"];
                f.txbCinClientValue = (string)dr["cin"];
                f.txbNomClientValue = (string)dr["nom"];
                f.txbTelValue = (string)dr["telephone"];
                f.txbJuridiqueValue = (string)dr["representant_legal"];
                f.txbNumSocieteValue = (string)dr["registre_commerce"];
                f.txbAdresseClientValue = (string)dr["adresse"];
                dr.Close();
                dr.Dispose();
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from adv_order where id_adv_order=@id";
                cmd.Parameters.Add("@id", idad);
                dr = cmd.ExecuteReader();
                dr.Read();
                f.txbIdAdvValue = dr["id_adv_order"].ToString();
                f.txbGenreAdvValue = (string)dr["type_adv_order"];
                f.txbCinAdvValue = (string)dr["cin"];
                f.txbNameAdvValue = (string)dr["nom"];
                f.txbJuridiqueAdvValue = (string)dr["representant_legal"];
                f.txbNumSocieteAdvValue = (string)dr["registre_commerce"];
                f.txbAdresseAdvValue = (string)dr["adresse"];
                dr.Close();
                dr.Dispose();
                cmd.Parameters.Clear();
                cn.Close();
                f.showEditButton = true;
                f.Show();
            }
            else
            {
                MessageBox.Show("يجب  اختيار السطر المراد التعديل عليه");
            }
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                PrintOneOrderForm p = new PrintOneOrderForm();
                p.idOrder = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlConnection cn = connection.getConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select id_client_order,id_adversaire_order from orderr where id_order=@id";
                cmd.Parameters.Add("@id", p.idOrder);
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                dr = cmd.ExecuteReader();
                dr.Read();
                p.idcli = (int)dr["id_client_order"];
                p.idadv = (int)dr["id_adversaire_order"];
                dr.Close();
                cn.Close();
                p.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void copyAlltoClipboardAllOrder()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            copyAlltoClipboardAllOrder();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cin = textBox2.Text;
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                DataTable dt = new DataTable();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select distinct ord.id_order,ord.signe_order,ord.date_order,ord.commissaire_judiciaire,ord.ville,ord.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',ord.decision,ord.type from orderr ord,client_order c,adv_order a where ord.etat='non archivé' and ord.id_adversaire_order=a.id_adv_order and ord.id_client_order=c.id_client_order and c.cin = @cin";
                cmd.Parameters.AddWithValue("@cin", cin);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                cn.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {

            }
            
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            if (textBox4.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show("المرجو تحديد الحقل او كتابة رقم الارشيف");
            }
            else
            {
                     cmd = new SqlCommand("update orderr set etat='archivé',num_archive=" + textBox4.Text + "where id_order='" + textBox3.Text + "'", cn);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("تمت الارشفة بنجاح");
                     textBox3.Clear();
                     textBox4.Clear();
                     refresh();

            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = textBox1.Text;
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                DataTable dt = new DataTable();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select distinct ord.id_order,ord.signe_order,ord.date_order,ord.commissaire_judiciaire,ord.ville,ord.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',ord.decision,ord.type from orderr ord,client_order c,adv_order a where (ord.id_order = @id or ord.signe_order=@num) and ord.etat='non archivé' and ord.id_adversaire_order=a.id_adv_order and ord.id_client_order=c.id_client_order";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@num", id);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                cn.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}