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
using AvocaBin.Operation;
using AvocaBin.Models.Plaintes;
using AvocaBin.Models;
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class جدول_الشكايات : DevExpress.XtraEditors.XtraForm
    {
        PlaintesOperations op;
        SqlCommand cmd;
        SqlConnection cn = connection.getConnection();

        public جدول_الشكايات()
        {
            op = new PlaintesOperations();
            InitializeComponent();
        }

        private void جدول_الشكايات_Load(object sender, EventArgs e)
        {
            getDataTable();
        }

        public void getDataTable()
        {
            dataGridView1.Rows.Clear();
            op = new PlaintesOperations();

            List<Plainte> plaintes = op.getAllPlante();
            foreach (Plainte pp in plaintes)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.IdPlainte,pp.DateCreation,pp.TypeTribunal,pp.TypePlaint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                String idplainte = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Plainte p = op.getPlanteById(idplainte).First();
                Plaignant plaignant = op.getPlaignantByCinAndId(p.IdPlaignant.ToString()).First();
                List<PlainteParPlaignant> ppp = op.getPlainteParPlaintes(p.IdPlainte);
                dataGridView2.Rows.Clear();
                foreach (var par in getParplaintes(ppp))
                {
                    dataGridView2.Rows.Add(par.IdParPlaignant, par.Nom, par.TypeParPlaignant);
                }
                lblnom.Text = plaignant.Nom;
                lbltype.Text = plaignant.TypePlaignant;
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private List<Par_plaignant> getParplaintes(List<PlainteParPlaignant> ppp) {
            List<Par_plaignant> parplains = new List<Par_plaignant>();
            foreach (PlainteParPlaignant item in ppp)
            {
                Par_plaignant pp = op.getParPlaignantByIdAndCIN(item.IdParPlaignant.ToString()).First();
                parplains.Add(pp);
                
            }
            return parplains;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButtonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                MessageBoxManager.Yes = "نعم";
                MessageBoxManager.No = "لا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.Yes)
                {
                    op.deletePlainte(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    history.AddHistory(" جدول الشكايات ", "الحدف", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    getDataTable();
                   

                }
                else
                {
                }
            }
        }

        private void simpleButtonModification_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                String idplaint = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                شكاية plai = new شكاية(idplaint);
               plai.btnModif.Visible = true;
                plai.Show();
                //this.Hide();
                history.AddHistory(" جدول الشكايات ", "التعديل", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("لا يمكنك التعديل . يجب اختيار الشكاية المراد التعديل عليها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButtonAjouter_Click(object sender, EventArgs e)
        {
            شكاية plai = new شكاية();
            plai.Show();
            this.Close();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImpr_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                String idplaint = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Form2 f = new Form2(idplaint);

                f.Show();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PrintAllPlaintes f = new PrintAllPlaintes();
            f.Show();
        }
        private void copyAlltoClipboardAllPlgnt()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardAllPlgnt();
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
            if (textBox2.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show("المرجو ادخال رقم الارشيف او تحديد الحقل");
            }
            else
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd = new SqlCommand("update plainte set etat='archivé',num_archive='" + textBox3.Text + "' where id_plainte='" + textBox2.Text+"'", cn);
                cmd.ExecuteNonQuery();
                getDataTable();

                lblnom.Text = "...";
                lbltype.Text = "...";
                dataGridView2.Rows.Clear();
                textBox2.Clear();
                textBox3.Clear();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            op = new PlaintesOperations();
            dataGridView1.Rows.Clear();
            List<Plainte> plaintes = op.getPlanteById(textBox1.Text);
            foreach (Plainte pp in plaintes)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.IdPlainte, pp.DateCreation, pp.TypeTribunal, pp.TypePlaint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
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