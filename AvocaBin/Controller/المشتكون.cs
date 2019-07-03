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
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class المشتكون : DevExpress.XtraEditors.XtraForm
    {    PlaintesOperations op;
    شكاية chikaya = new شكاية();
        public المشتكون( شكاية chikaya)
        {
            op=new PlaintesOperations();
            InitializeComponent();
            this.chikaya = chikaya;
        }
        public المشتكون()
        {
            op = new PlaintesOperations();
            InitializeComponent();
           
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void المشتكون_Load(object sender, EventArgs e)
        {
            cb_genre_plai.Items.Add("طبيعي");
            cb_genre_plai.Items.Add("معنوي");
            getDataTable();
        }

        public void getDataTable()
        {
            dataGridView1.Rows.Clear();

            List<Plaignant> pps = op.getAllPlaignant();
            foreach (Plaignant pp in pps)
            {
                try
                {
                    dataGridView1.Rows.Add(pp.IdPlaignant, pp.Cin,pp.Adresse,pp.Nom,pp.Telephone, pp.RepresentantLegal, pp.RegistreDeCommerce1, pp.TypePlaignant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cb_genre_plai.Text=="" || txb_name.Text=="")
            {
                MessageBox.Show("المرجو ملا الخانات");
            }
            else
            {
                Plaignant pp = new Plaignant();
                pp.Cin = txb_cin.Text;
                pp.Nom = txb_name.Text;
                pp.RegistreDeCommerce1 = txb_num_societe.Text;
                pp.RepresentantLegal = txb_juridique.Text;
                pp.Adresse = txb_adresse.Text;
                pp.Telephone = txb_tele.Text;
                //  pp.TypeParPlaignant=cb_genre_plai.selectedItem
                pp.TypePlaignant = cb_genre_plai.SelectedItem.ToString();
                op.addPlaignant(pp);
                chikaya.getDataTablePlaignant();
                getDataTable();
                history.AddHistory("المشتكون", "الاضافة", txb_cin.Text);
                simpleButton1.Enabled = false;
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
            txb_tele.Clear();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    op.deletePlaignant(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    getDataTable();
                    chikaya.getDataTablePlaignant();
                    history.AddHistory("المشتكون", "الحدف", txb_cin.Text);
                }
                else
                {
                    MessageBox.Show("يجب اختيار مشتكي");
                }
                
            }
            else
            {
            }
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
          
            txb_cin.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txb_adresse.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txb_name.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txb_tele.Text=dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txb_juridique.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txb_num_societe.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cb_genre_plai.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString(); ;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && txb_name.Text!="")
            {

                Plaignant pp = new Plaignant();
                pp.IdPlaignant = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                pp.Cin = txb_cin.Text;
                pp.Nom = txb_name.Text;
                pp.RegistreDeCommerce1 = txb_num_societe.Text;
                pp.RepresentantLegal = txb_juridique.Text;
                pp.Adresse = txb_adresse.Text;
                pp.Telephone = txb_tele.Text;
                //  pp.TypeParPlaignant=cb_genre_plai.selectedItem
                pp.TypePlaignant = cb_genre_plai.SelectedItem.ToString();
                op.updatePlaignant(pp);
                getDataTable();
                chikaya.getDataTablePlaignant();
                history.AddHistory("المشتكون", "التعديل", txb_cin.Text);
                clearText();
            }
            else
            {
                MessageBox.Show("يجب اختيار مشتكي");
            }
            }

        private void btn_searsh_Click(object sender, EventArgs e)
        {
            

        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txb_searsh.Clear();
        }
        private void copyAlltoClipboardAdvs()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {

            copyAlltoClipboardAdvs();
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

        private void cb_genre_plai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_genre_plai.Text == "طبيعي")
            {
                txb_juridique.Enabled = false;
                txb_num_societe.Enabled = false;
                txb_cin.Enabled = true;
            }
            if (cb_genre_plai.Text == "معنوي")
            {
                txb_cin.Enabled = false;
                txb_juridique.Enabled = true;
                txb_num_societe.Enabled = true;
            }
        }

        private void txb_searsh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            // op.getParPlaignantByIdAndCIN(txb_searsh.Text);
            foreach (Plaignant pp in op.getPlaignantByCinAndId(txb_searsh.Text))
            {
                try
                {
                    dataGridView1.Rows.Add(pp.IdPlaignant, pp.Cin, pp.Adresse, pp.Nom, pp.Telephone, pp.RepresentantLegal, pp.RegistreDeCommerce1, pp.TypePlaignant);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                imprimer_plaignant frm = new imprimer_plaignant(id);
                frm.Show();
            }
            
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string text = txb_searsh.Text;
                impimeAllPlaingnants frm = new impimeAllPlaingnants(text);
                frm.Show();
            }
        }

        private void label9_Click(object sender, EventArgs e)
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
      
