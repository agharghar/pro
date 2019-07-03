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
using AvocaBin.Models.cause;
using AvocaBin.Operation;
using System.Data.SqlClient;
using AvocaBin.Controller;



namespace AvocaBin
{
    public partial class اليومية : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cn = connection.getConnection();
        Cause_Operations co = new Cause_Operations();
        SqlCommand cmd;
        SqlDataAdapter ad;
        DataSet ds;
        DataSetAgenda dsa;

        public اليومية()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void اليومية_Load(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            //dsa = new DataSetAgenda();
            //  ad.Fill((DataTable)dsa.Agenda);
            ad.Fill(ds, "a");
            dataGridView1.DataSource = ds.Tables["a"];
            cn.Close();
            radioButton1.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if (textBox1.Text == "")
            {
                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, "a");
                dataGridView1.DataSource = ds.Tables["a"];
            }
            else
            {
                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (c.id_cause like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.type_cause like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.tribunal like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv)  order by c.tribunal", cn);
                ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, "a");
                dataGridView1.DataSource = ds.Tables["a"];
            }

            cn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                simpleButton1.Enabled = false;
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, "a");
                dataGridView1.DataSource = ds.Tables["a"];
                cn.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Clear();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                ad = new SqlDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds, "a");
                dataGridView1.DataSource = ds.Tables["a"];
                cn.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            simpleButton1.Enabled = true;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {


                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    // MessageBox.Show("isk tcha");
                    MessageBoxManager.OK = "حسنا";

                    MessageBoxManager.Register();
                    DialogResult dr = MessageBox.Show("يجب على التاريخ الاخير ان يكون اكبر من الاخير", "تنبيه", MessageBoxButtons.OK);
                    MessageBoxManager.Unregister();

                }
                else
                {

                    cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (s.date_session between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "') and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv  order by c.tribunal", cn);
                    ad = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    ad.Fill(ds, "a");
                    dataGridView1.DataSource = ds.Tables["a"];
                }

                cn.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int etat = -1;
            string date1 = null;
            string date2 = null;
            string id = null;

            if (radioButton2.Checked == true && textBox1.Text == "")
            {

                cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                ad = new SqlDataAdapter(cmd);
                dsa = new DataSetAgenda();
                ad.Fill(dsa.Agenda);
                //dataGridView1.DataSource = ds.Tables["a"];

            }
            else
            {
                if (radioButton2.Checked == true && textBox1.Text != "")
                {
                    cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (c.id_cause like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.type_cause like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv) or (c.tribunal like'" + textBox1.Text + "%' and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv)  order by c.tribunal", cn);
                    ad = new SqlDataAdapter(cmd);
                    dsa = new DataSetAgenda();
                    ad.Fill(dsa.Agenda);
                    etat = 0;
                    id = textBox1.Text;

                }
                else
                {
                    if (radioButton1.Checked == true && dateTimePicker2.Enabled == true && simpleButton1.Enabled == true && dataGridView1.Rows.Count != 0)
                    {
                        cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (s.date_session between'" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "') and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv  order by c.tribunal", cn);
                        ad = new SqlDataAdapter(cmd);
                        dsa = new DataSetAgenda();
                        ad.Fill(dsa.Agenda);
                        date1 = dateTimePicker1.Value.ToShortDateString();
                        date2 = dateTimePicker2.Value.ToShortDateString();
                        //dataGridView1.DataSource = ds.Tables["a"];
                    }
                    else
                    {
                        if (radioButton1.Checked == true && dateTimePicker2.Enabled == true && simpleButton1.Enabled == true && dataGridView1.Rows.Count == 0)
                        {
                            cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where (s.date_session between'" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "') and s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv  order by c.tribunal", cn);
                            ad = new SqlDataAdapter(cmd);
                            dsa = new DataSetAgenda();
                            ad.Fill(dsa.Agenda);
                            date1 = dateTimePicker1.Value.ToShortDateString();
                            date2 = dateTimePicker2.Value.ToShortDateString();
                        }
                        else
                        {
                            cmd = new SqlCommand("select s.id_cause as[المرجع],cl.nom as[الموكل],a.nom_adv as[الخصم],c.num_cause_tribunal as [رقم القضية],c.type_cause as [نوع القضية],s.date_session as[تاريخ الجلسة],c.juge as[القاضي],s.decision as[الاجراء],c.ville as [المدينة],c.tribunal as [المحكمة] from cause c,sessione s,client_cause cl,adversaire_cause a where s.id_cause=c.id_cause and c.id_client=cl.id_client_cause and a.id_adversaire_cause=c.id_adv order by c.tribunal", cn);
                            ad = new SqlDataAdapter(cmd);
                            dsa = new DataSetAgenda();
                            ad.Fill(dsa.Agenda);
                            etat = 0;

                        }

                    }
                }
            }
            cn.Close();
            imprimerAgenda frm = new imprimerAgenda(etat, date1, date2, id);
            frm.Show();

        }
        private void copyAlltoClipboardAgenda()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            copyAlltoClipboardAgenda();
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

        private void label3_Click(object sender, EventArgs e)
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