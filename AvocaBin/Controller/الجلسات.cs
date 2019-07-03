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
using System.Data.SqlClient;
using AvocaBin.Operation;
using AvocaBin.Models.cause;
using AvocaBin.Models;

namespace AvocaBin
{
    public partial class الجلسات : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cn = connection.getConnection();
        Cause_Operations co = new Cause_Operations();
        DataSet ds=new DataSet();
        SqlDataAdapter ad;
        SqlCommand cmd;

        public الجلسات()
        {
            InitializeComponent();
        }
        public void getDataTable_cause()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
            cmd = new SqlCommand("select id_cause from cause where etat='non archivé'", cn);
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "b");
            cb_id_cause.DataSource = ds.Tables["b"];
            cb_id_cause.DisplayMember = "id_cause";
            
            cn.Close();
        }
       public void getdata()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
            cmd = new SqlCommand("select s.id_session as [رقم الجلسة],s.id_cause as[مرجع القضية],cl.nom as[الموكل],a.nom_adv as[الخصم],s.date_session as[تاريخ الجلسة],s.decision as[الاجراء] from cause c,sessione s,client_cause cl,adversaire_cause a where c.etat='non archivé' and  s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by s.date_session DESC", cn);
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "a");
            dataGridView1.DataSource = ds.Tables["a"];
            cn.Close();
        }
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (txt_decision.Text=="" || cb_id_cause.Text=="")
            {
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("المرجو ملئ جميع الحقول", "تنبيه", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();

            }
            else
            {
                try
                {
                    //cn.Open();
                    Session se = new Session();
                    se.Date_session = dateTimePicker1.Value;
                    se.Decision = txt_decision.Text;
                    se.Id_cause = cb_id_cause.Text;
                    se.Phrase_operative1 = textBox1.Text;
                    co.add_session(se);
                    getdata();
                    history.AddHistory("الجلسات", "الاضافة", cb_id_cause.Text);
                    txt_decision.Clear();
                    textBox1.Clear();
                    //cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void الجلسات_Load(object sender, EventArgs e)
        {
            getdata();
            getDataTable_cause();
        }

        private void txb_searsh_TextChanged(object sender, EventArgs e)
        {
            if (txb_searsh.Text=="")
            {
                getdata();
            }
            else
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd = new SqlCommand("select s.id_session as [رقم الجلسة],s.id_cause as [المرجع],cl.nom as [الموكل],a.nom_adv as [الخصم],s.date_session as [تاريخ الجلسة],s.decision as [الاجراء] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause like'%" + txb_searsh.Text + "%' and c.id_cause=s.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv", cn);
                ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, "k");
                dataGridView1.DataSource = ds.Tables["k"];
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            txt_decision.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txb_searsh.Clear();
        }
        private void copyAlltoClipboardSession()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardSession();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if (dataGridView1.Rows.Count > 0 && txt_decision.Text!="")
            {
                cmd = new SqlCommand("update sessione set decision='"+txt_decision.Text+"', date_session='"+dateTimePicker1.Value.ToString()+"' where id_session="+dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل بنجاح");
                txt_decision.Clear();

            }
            else
            {
                MessageBox.Show("المرجو تحديد الحقل");
            }
            getdata();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if (dataGridView1.Rows.Count > 0)
            {
                cmd = new SqlCommand("delete sessione where id_session=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحذف بنجاح");

            }
            else
            {

            }
            getdata();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                
                cb_id_cause.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_decision.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                cmd = new SqlCommand("select Phrase_operative from sessione where id_session="+dataGridView1.SelectedRows[0].Cells[0].Value, cn);

                textBox1.Text = cmd.ExecuteScalar().ToString();
            }
            
        }

        private void txt_decision_TextChanged(object sender, EventArgs e)
        {
            if (txt_decision.Text=="مداولة" || txt_decision.Text=="المداولة")
            {
                textBox1.Visible = true;
                label5.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                label5.Visible = false;

            }
		  
	
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 400;
                mouseY = MousePosition.Y - 40;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}