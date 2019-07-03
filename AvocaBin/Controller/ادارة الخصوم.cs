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
using System.Data.SqlClient;
using AvocaBin.Models.cause;
using AvocaBin.Controller;
using AvocaBin.Models;
namespace AvocaBin
{
    public partial class ادارة_الخصوم : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cn = connection.getConnection();
        Cause_Operations co = new Cause_Operations();
        الموضوع ma=new الموضوع();

        public ادارة_الخصوم(الموضوع ma)
        {
            co = new Cause_Operations();
            InitializeComponent();
            this.ma = ma;
        }

        public ادارة_الخصوم()
        {
            InitializeComponent();
        }

        public void testdata() 
        {
            if (dataGridView1.Rows.Count == 0)
            {
                btn_remove.Enabled = false;
                btn_edit.Enabled = false;
                btn_imprimer.Enabled = false;
                btn_imprimer_all.Enabled = false;
            }
            else
            {
                btn_remove.Enabled = true;
                btn_edit.Enabled = true;
                btn_imprimer.Enabled = true;
                btn_imprimer_all.Enabled = true;
            }
        }

        public void getDataTable()
        {
            dataGridView1.Rows.Clear();
            
            co = new Cause_Operations();
            List<adversaire_cause> adversaire_causes = co.getAllAdversaire_cause();
            foreach (adversaire_cause cc in adversaire_causes)
            {
                try
                {
                    dataGridView1.Rows.Add(cc.Id_adv_cause,cc.Nom,cc.Adjoint, cc.Type_adversaire, cc.Cin, cc.Registre_commerce, cc.Representant_legal, cc.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            testdata();
            
        }
        public void vider_champ()
        {
            //TxB_ident.Clear();
            txb_name.Clear();
            txb_cin.Clear();
            txb_cin.ReadOnly = false;

            //txb_tele.Clear();
            txb_adresse.Clear();
            txb_juridique.Clear();
            txb_num_societe.ReadOnly = false;
            txt_adjoint.Clear();
            txb_num_societe.Clear();
        }
        public void search()
        {
            if (txb_searsh.Text == "")
            {
                dataGridView1.Rows.Clear();
                co = new Cause_Operations();
                List<adversaire_cause> adv_causes = co.getAllAdversaire_cause();
                foreach (adversaire_cause cc in adv_causes)
                {
                    try
                    {
                        dataGridView1.Rows.Add(cc.Id_adv_cause,cc.Nom, cc.Adjoint, cc.Type_adversaire, cc.Cin, cc.Registre_commerce, cc.Representant_legal, cc.Adresse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                testdata();

            }
            else
            {
                dataGridView1.Rows.Clear();
                co = new Cause_Operations();
                List<adversaire_cause> adv_cause = co.searchAdversaire_cause(txb_searsh.Text);
                foreach (adversaire_cause cc in adv_cause)
                {
                    try
                    {
                        dataGridView1.Rows.Add(cc.Id_adv_cause,cc.Nom, cc.Adjoint, cc.Type_adversaire, cc.Cin, cc.Registre_commerce, cc.Representant_legal, cc.Adresse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                testdata();
            }
        }
        
        private void ادارة_الخصوم_Load(object sender, EventArgs e)
        {
            
            getDataTable();
           // testdata();
            
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txb_name.Text == "")
                {
                        MessageBoxManager.OK = "حسنا";
                        MessageBoxManager.Register();
                        DialogResult dr = MessageBox.Show("المرجو ملئ الحقل المخصص بالاسم", "", MessageBoxButtons.OK);
                        MessageBoxManager.Unregister();
                    
                    //else
                    //{

                    //    if (CB_genre_Adv.Text == "معنوي" &&( txb_name.Text == "" || txb_adresse.Text == "" || txt_adjoint.Text=="" || txb_num_societe.Text==""))
                    //    {
                    //        //MessageBox.Show("المرجو ملئ الحقل المخصص لالسجل التجاري و الممثل القانوني ");
                    //        MessageBoxManager.OK = "حسنا";
                    //        MessageBoxManager.Register();
                    //        DialogResult dr = MessageBox.Show("المرجو ملئ جميع الحقول", "", MessageBoxButtons.OK);
                    //        MessageBoxManager.Unregister();
                    //    }
                    //    else
                    //    {
                    //        if (CB_genre_Adv.Text == "طبيعي" && ( txb_cin.Text == "" || txb_name.Text=="" || txb_adresse.Text==""))
                    //        {
                    //            //MessageBox.Show("المرجو ملئ الحقل المخصص لرقم البطاقة الوطنية ");
                    //            MessageBoxManager.OK = "حسنا";
                    //            MessageBoxManager.Register();
                    //            DialogResult dr = MessageBox.Show("المرجو ملئ الحقل المخصص لرقم البطاقة الوطنية", "تنبيه", MessageBoxButtons.OK);
                    //            MessageBoxManager.Unregister();
                }
                else
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    adversaire_cause c = new adversaire_cause();
                    c.Type_adversaire = CB_genre_Adv.Text;
                    c.Cin = txb_cin.Text;
                    c.Adjoint = txt_adjoint.Text;
                    c.Nom = txb_name.Text;
                    c.Representant_legal = txb_juridique.Text;
                    c.Registre_commerce = txb_num_societe.Text;
                    c.Adresse = txb_adresse.Text;
                    co.add_adversaire_cause(c);
                    getDataTable();
                    ma.getDataTable1();
                    history.AddHistory(" ادارة الخصوم", "الاضافة", txb_name.Text);
                    cn.Close();
                    btn_ajouter.Enabled = false;
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
            adversaire_cause cc = new adversaire_cause();
            if (txb_cin.Text == "" && txb_num_societe.Text=="")
            {
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("يجب إختيار السجل المراد تعديله","", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
                //MessageBox.Show("يجب إختيار السجل المراد تعديله");
            }
            else
            {
                cc.Id_adv_cause = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                cc.Type_adversaire = CB_genre_Adv.Text;
                cc.Cin = txb_cin.Text;
                cc.Nom = txb_name.Text;
                cc.Adjoint = txt_adjoint.Text;
                cc.Representant_legal = txb_juridique.Text;
                cc.Registre_commerce = txb_num_societe.Text;
                cc.Adresse = txb_adresse.Text;
                co.update_adversaire_cause(cc);
                getDataTable();
                ma.getDataTable();
                vider_champ();
               
            }
            history.AddHistory(" ادارة الخصوم", "التعديل", txb_name.Text);
            cn.Close();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
                testdata();
           
                MessageBoxManager.Yes = "نعم";
                MessageBoxManager.No = "لا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
                MessageBoxManager.Unregister();
                if (dr == DialogResult.Yes)
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                
                    int id;
                    id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    co.deleteAdversaire_cause(id);
                    getDataTable();
                    ma.getDataTable();
                    vider_champ();
                    txb_searsh.Clear();
                    history.AddHistory(" ادارة الخصوم", "الحدف", txb_name.Text);
                    cn.Close();
                    
                }
                else
                {

                }
            }
        

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            vider_champ();
            btn_ajouter.Enabled = true;
            CB_genre_Adv.Enabled = true;
           
            if (CB_genre_Adv.Text == "طبيعي")
            {

                txb_cin.ReadOnly = false;
            }
            else
            {
                txb_juridique.ReadOnly = false;
                txb_num_societe.ReadOnly = false;
                txb_cin.ReadOnly = false;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            btn_ajouter.Enabled = false;
            if (CB_genre_Adv.Text=="طبيعي")
            {
                //txb_cin.ReadOnly = true;
                txb_num_societe.Clear();
                txb_juridique.Clear();
            }
            else
            {
                //txb_num_societe.ReadOnly = true;
                CB_genre_Adv.Enabled = false;
                
            }
            if (dataGridView1.Rows.Count>0)
            {
                txb_cin.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txb_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_adjoint.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                CB_genre_Adv.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim(); ;
                txb_num_societe.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txb_juridique.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txb_adresse.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            else
            {

            }
            
        }

        private void CB_genre_Adv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_genre_Adv.Text == "طبيعي")
            {
                txb_name.Enabled = true;
                txb_cin.Enabled = true;
                txb_adresse.Enabled = true;
                txb_juridique.Enabled = false;
                txb_juridique.Clear();
                txb_num_societe.Enabled = false;
                txb_num_societe.Clear();
                txt_adjoint.Enabled = true;
                
            }
            else
            {
                txb_name.Enabled = true;
                txb_cin.Enabled = true;
                txb_adresse.Enabled = true;
                txb_juridique.Enabled = true;
                txb_num_societe.Enabled = true;
                txt_adjoint.Enabled = true;
                //txb_num_societe.ReadOnly = false;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
        }

        private void txb_searsh_TextChanged(object sender, EventArgs e)
        {
            search();
            //getDataTable();
        }

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string type = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                imprimer_adv_cause frm = new imprimer_adv_cause(id, type);
                frm.Show();
            }

        }

        private void btn_imprimer_all_Click(object sender, EventArgs e)
        {
            ImprimerAllAdv frm = new ImprimerAllAdv(txb_searsh.Text);
            frm.Show();
        }
        private void copyAlltoClipboar()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            copyAlltoClipboar();
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

        private void txt_adjoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txb_searsh.Clear();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}