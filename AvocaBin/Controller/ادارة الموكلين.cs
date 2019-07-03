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
using AvocaBin.Models;
using AvocaBin.Operation;
using System.Data.SqlClient;
using AvocaBin.Models.cause;
using AvocaBin.Controller;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;

namespace AvocaBin
{
    public partial class ادارة_الموكلين : DevExpress.XtraEditors.XtraForm
    {

        //DataSet ds = new DataSet();
        SqlConnection cn = connection.getConnection();
        Cause_Operations co = new Cause_Operations();
        الموضوع ma=new الموضوع();
        ImprimerClientCause ImpClientCause;
        public ادارة_الموكلين(الموضوع ma)
        {
            co = new Cause_Operations();
            InitializeComponent();
            this.ma = ma;
        }
        public ادارة_الموكلين()
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
           // client_cause cc = new client_cause();
            co = new Cause_Operations();
            List<client_cause> client_causes = co.getAllClients_cause();
            foreach (client_cause cc in client_causes)
            {  try
                {
                    dataGridView1.Rows.Add(cc.Id_client_cause,cc.Nom,cc.Type_client,cc.Cin,cc.Representant_legal,cc.Registre_commerce, cc.Telephone, cc.Adresse);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            testdata();
        }

        public void search()
        {
            if (textBox1.Text=="")
            {
                dataGridView1.Rows.Clear();
                co = new Cause_Operations();
                List<client_cause> client_causes = co.getAllClients_cause();
                foreach (client_cause cc in client_causes)
                {
                    try
                    {
                        dataGridView1.Rows.Add(cc.Id_client_cause,cc.Nom,cc.Type_client, cc.Cin, cc.Representant_legal, cc.Registre_commerce, cc.Telephone, cc.Adresse);
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
                List<client_cause> client_causes = co.searchclient_cause(textBox1.Text);
                foreach (client_cause cc in client_causes)
                {
                    try
                    {
                        dataGridView1.Rows.Add(cc.Id_client_cause,cc.Nom, cc.Type_client, cc.Cin,cc.Representant_legal, cc.Registre_commerce, cc.Telephone, cc.Adresse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                testdata();
            }
            
        }
        public void vider_champ()
        {
            //txb_ident_client.Clear();
            txb_name.Clear();
            txb_cin.Clear();
            txb_tele.Clear();
            txb_adresse.Clear();
            txb_juridique.Clear();
            txb_num_societe.Clear();
        }
        
        
        private void ادارة_الموكلين_Load(object sender, EventArgs e)
        {
            
            getDataTable();            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

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
                }
                //else
                //{
                //    if (txb_genre_client.Text == "معنوي" && txb_juridique.Text == "" && txb_num_societe.Text == "" && txb_name.Text=="" && txb_tele.Text=="" && txb_adresse.Text=="")
                //    {
                //       // MessageBox.Show("المرجو ملئ الحقل المخصص لالسجل التجاري و الممثل القانوني ");
                //        MessageBoxManager.OK = "حسنا";
                //        MessageBoxManager.Register();
                //        DialogResult dr = MessageBox.Show("المرجو ملئ جميع الحقول", "", MessageBoxButtons.OK);
                //        MessageBoxManager.Unregister();
                //    }
                //    else
                //    {
                //        if (txb_genre_client.Text == "طبيعي" && (txb_cin.Text == "" || txb_name.Text=="" || txb_tele.Text=="" || txb_adresse.Text==""))
                //        {
                //           // MessageBox.Show("المرجو ملئ الحقل المخصص لرقم البطاقة الوطنية ");
                //            MessageBoxManager.OK = "حسنا";
                //            MessageBoxManager.Register();
                //            DialogResult dr = MessageBox.Show("المرجو ملئ جميع الحقول", "تنبيه", MessageBoxButtons.OK);
                //            MessageBoxManager.Unregister();
                //        }
                        else
                        {
                            if (cn.State == ConnectionState.Closed)
                            {
                                cn.Open();
                            }
                
                            client_cause c = new client_cause();
                            c.Type_client = txb_genre_client.Text;
                            c.Cin = txb_cin.Text;
                            c.Nom = txb_name.Text;
                            c.Telephone = txb_tele.Text;
                            c.Representant_legal = txb_juridique.Text;
                            c.Registre_commerce = txb_num_societe.Text;
                            c.Adresse = txb_adresse.Text;
                            co.add_client_cause(c);
                            getDataTable();
                            ma.getDataTable();
                            cn.Close();
                            btn_ajouter.Enabled = false;

                        }
                        history.AddHistory(" ادارة الموكلين", "الاضافة", txb_cin.Text);

                    }
              
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txb_genre_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txb_genre_client.Text== "طبيعي")
            {
                txb_name.Enabled = true;
                txb_cin.Enabled = true;
                txb_tele.Enabled = true;
                txb_adresse.Enabled = true;
                txb_juridique.Enabled = false;
                txb_juridique.Clear();
                txb_num_societe.Enabled = false;
                txb_num_societe.Clear();
                label4.Visible = false;
                //txt_ident.Visible=false;
              //  txb_cin.Visible = true;
                label8.Visible = true;

            }
            else
            {
                txb_name.Enabled = true;
                txb_cin.Enabled = true;
                txb_tele.Enabled = true;
                txb_adresse.Enabled = true;
                txb_juridique.Enabled = true;
                txb_num_societe.Enabled = true;
                txb_num_societe.ReadOnly = false;
                label4.Visible = true;
                //txt_ident.Visible = true;
              //  txb_cin.Visible = false;
                label8.Visible = false;

            }
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            vider_champ();
            btn_ajouter.Enabled = true;
            txb_genre_client.Enabled = true;
            if (txb_genre_client.Text == "طبيعي")
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
             client_cause cc = new client_cause();
             if (txb_cin.Text == "" && txb_num_societe.Text == "")
             {
                 MessageBoxManager.OK = "حسنا";
                 MessageBoxManager.Register();
                 DialogResult dr = MessageBox.Show("يجب إختيار السجل المراد تعديله", "", MessageBoxButtons.OK);
                 MessageBoxManager.Unregister();
                 //MessageBox.Show("يجب إختيار السجل المراد تعديله");
             }
             else
             {


                 cc.Id_client_cause = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                 cc.Type_client = txb_genre_client.Text;
                 cc.Cin = txb_cin.Text;
                 cc.Nom = txb_name.Text;
                 cc.Telephone = txb_tele.Text;
                 cc.Representant_legal = txb_juridique.Text;
                 cc.Registre_commerce = txb_num_societe.Text;
                 cc.Adresse = txb_adresse.Text;
                 co.update_client_cause(cc);
                 getDataTable();
                 ma.getDataTable();
                 vider_champ();

                 history.AddHistory(" ادارة الموكلين", "التعديل", txb_cin.Text);
                 cn.Close();
             }
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
                co.deleteClient_cause(id);
                getDataTable();
                ma.getDataTable();
                vider_champ();
                textBox1.Clear();
                history.AddHistory(" ادارة الموكلين", "الحدف", txb_cin.Text);
                cn.Close();
            }
            else
            {

            }
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            btn_ajouter.Enabled = false;
            if (txb_genre_client.Text == "طبيعي")
            {
               // txb_cin.ReadOnly = true;
                txb_genre_client.Enabled = false;
                txb_num_societe.Clear();
                txb_juridique.Clear();
            }
            else
            {
               // txb_num_societe.ReadOnly = true;
                txb_genre_client.Enabled = false;
            }
            if (dataGridView1.Rows.Count > 0)
            {
                txb_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txb_genre_client.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
                txb_cin.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                txb_juridique.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                txb_num_societe.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
                txb_tele.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
                txb_adresse.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
                
            }
            else
            {

            }

        }
        
        private void ادارة_الموكلين_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string type = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                ImprimerClientCause frm = new ImprimerClientCause(id, type);
                frm.Show();
            }

        }

        private void btn_imprimer_all_Click(object sender, EventArgs e)
        {
            ImprimerAllClientCause frm = new ImprimerAllClientCause(textBox1.Text);
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

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void dropDownButton2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
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