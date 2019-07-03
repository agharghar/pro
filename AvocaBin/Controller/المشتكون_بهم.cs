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
using AvocaBin.Controller;


namespace AvocaBin
{
    public partial class المشتكون_بهم : DevExpress.XtraEditors.XtraForm
    {
        شكاية chikaya = new شكاية();
        PlaintesOperations op;

        public المشتكون_بهم(شكاية chikaya)
        {
            op = new PlaintesOperations();
            InitializeComponent();
            this.chikaya = chikaya;
        }

        public المشتكون_بهم()
        {
            op = new PlaintesOperations();
            InitializeComponent();
        }

        private void cb_genre_plai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void المشتكون_بهم_Load(object sender, EventArgs e)
        {
            
            cb_genre_plai.Items.Add("طبيعي");
            cb_genre_plai.Items.Add("معنوي");
            getDataTable();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cb_genre_plai.Text=="" || txb_name.Text=="")
            {
                MessageBox.Show("المرجو ملا الخانات");
            }
            else
            {
                Par_plaignant pp = new Par_plaignant();
                pp.Cin = txb_cin.Text;
                pp.Nom = txb_name.Text;
                pp.RegistreDeCommerce1 = txb_num_societe.Text;
                pp.RepresentantLegal = txb_juridique.Text;
                pp.Adresse = txb_adresse.Text;
                //  pp.TypeParPlaignant=cb_genre_plai.selectedItem
                pp.TypeParPlaignant = cb_genre_plai.SelectedItem.ToString();
                op.addParPlaignant(pp);
                chikaya.getDataTableParPlaignant();
                getDataTable();
                simpleButton1.Enabled = false;
                history.AddHistory("المشتكون بهم", "الاضافة", txb_cin.Text);
                simpleButton1.Enabled = false;
               
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {




        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr=MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
                    op.deleteParPlaignant(id);
                    MessageBox.Show("تم الحذف بنجاح");
                    getDataTable();
                    chikaya.getDataTableParPlaignant();
                    history.AddHistory("المشتكون بهم", "الحدف", txb_cin.Text);
            }
            else
            {
            }
  
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                txb_cin.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txb_name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txb_num_societe.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txb_juridique.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txb_adresse.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                cb_genre_plai.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString(); 
            }
           
        }

        public void getDataTable()
        {
            dataGridView1.Rows.Clear();
            op = new PlaintesOperations();

            List<Par_plaignant> pps = op.getAllParPlaignant();
            foreach (Par_plaignant pp in pps)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.IdParPlaignant, pp.Cin, pp.Nom, pp.RegistreDeCommerce1, pp.RepresentantLegal, pp.TypeParPlaignant, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            testdata();
        }
        public void testdata()
        {
            if (dataGridView1.Rows.Count == 0)
            {

                //simpleButton1.Enabled = false;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
              
            }
            else
            {
               // simpleButton1.Enabled = true;
                simpleButton3.Enabled = true;
                simpleButton4.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            clearText();
            simpleButton1.Enabled = true;
        }

        public void clearText()
        {
           
            txb_cin.Clear();
            txb_name.Clear();
            txb_num_societe.Clear();
            txb_juridique.Clear();
            txb_adresse.Clear();
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && txb_name.Text != "")
            {
                Par_plaignant pp = new Par_plaignant();
                pp.IdParPlaignant = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                pp.Cin = txb_cin.Text;
                pp.Nom = txb_name.Text;
                pp.RegistreDeCommerce1 = txb_num_societe.Text;
                pp.RepresentantLegal = txb_juridique.Text;
                pp.Adresse = txb_adresse.Text;
                //  pp.TypeParPlaignant=cb_genre_plai.selectedItem
                pp.TypeParPlaignant = cb_genre_plai.SelectedItem.ToString();
                op.updateParPlaignant(pp);
                getDataTable();
                chikaya.getDataTableParPlaignant();
                history.AddHistory("المشتكون بهم", "التعديل", txb_cin.Text);
            }
            else
            {
                MessageBox.Show("يجب اختيار مشتكي به");
            }
            
        }

        private void btn_searsh_Click(object sender, EventArgs e)
        {
            
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txb_searsh.Clear();
        }
        private void copyAlltoClipboardAdv()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            copyAlltoClipboardAdv();
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

        private void txb_searsh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            // op.getParPlaignantByIdAndCIN(txb_searsh.Text);
            foreach (Par_plaignant pp in op.getParPlaignantByIdAndCIN(txb_searsh.Text))
            {
                try
                {

                    dataGridView1.Rows.Add(pp.IdParPlaignant, pp.Cin, pp.Nom, pp.RepresentantLegal, pp.RegistreDeCommerce1, pp.TypeParPlaignant, pp.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                imprimerParPlai frm = new imprimerParPlai(id);
                frm.Show();
            }
            
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                imprimerAllPar_Plai frm = new imprimerAllPar_Plai(txb_searsh.Text);
                frm.Show();
            }
        }

        private void label7_Click_1(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}