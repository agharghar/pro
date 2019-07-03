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
using AvocaBin.Operation;
using AvocaBin.Models;

namespace AvocaBin.Controller
{
    public partial class cause_archivé : Form
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd;
        SqlDataAdapter dr;
        DataSet ds;
        Cause_Operations co = new Cause_Operations();
        
        public cause_archivé()
        {
            InitializeComponent();
        }
        public DataSet GetData()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_session as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause order by date_session DESC", cn);
            dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds, "causes");
            cn.Close();
            return ds;
        }
        public void testdata()
        {
            if (dataGridView1.Rows.Count == 0)
            {
               // simpleButton1.Enabled = false;
                simpleButton2.Enabled = false;
                btn_imprimer.Enabled = false;
                btn_imprimerAll.Enabled = false;
            }
            else
            {
                //simpleButton1.Enabled = true;
                simpleButton2.Enabled = true;
                btn_imprimer.Enabled = true;
                btn_imprimerAll.Enabled = true;
            }
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
        private void cause_archivé_Load(object sender, EventArgs e)
        {
            
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_session as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause order by date_session ASC", cn);
            dr = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dr.Fill(ds, "causes");
            dataGridView1.DataSource = ds.Tables["causes"];
            cn.Close();
            testdata();
        }

        private void btn_searsh_Click(object sender, EventArgs e)
        {
            if (txt_search.Text != "")
            {
                if (cn.State==ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_creation as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where( c.id_cause like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( c.num_cause_tribunal like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.nom like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.cin like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( c.num_archive like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) order by date_session ASC", cn);
                dr = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dr.Fill(ds, "causes");
                dataGridView1.DataSource = ds.Tables["causes"];
                testdata();
                cn.Close();
                history.AddHistory("القضية", "البحث", txt_search.Text);
            }
           
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
        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Imprimer_cause frm = new Imprimer_cause(id);
            frm.Show();
        }

        private void btn_imprimerAll_Click(object sender, EventArgs e)
        {
            string id = txt_search.Text;
            imprimerAllCauseArchive frm = new imprimerAllCauseArchive(id);
            frm.Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
            if (txt_search.Text == "")
            {
                cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_session as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause order by date_session ASC", cn);
                dr = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dr.Fill(ds, "causes");
                dataGridView1.DataSource = ds.Tables["causes"];
                testdata();
            }
            else
            {
                if (txt_search.Text != "")
                {
                    cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_creation as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where( c.id_cause like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( c.num_cause_tribunal like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.nom like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( cl.cin like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) or ( c.num_archive like '%" + txt_search.Text + "%' and c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause) order by date_session ASC", cn);
                    dr = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              dr.Fill(ds, "causes");
                    dataGridView1.DataSource = ds.Tables["causes"];
                    testdata();
                    cn.Close();
                    history.AddHistory("القضية", "البحث", txt_search.Text);
                }
            }

            cn.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                co.deleteCause(id);
                dataGridView1.DataSource = GetData().Tables["causes"];
                testdata();
                history.AddHistory("القضية", "الحدف", txt_search.Text);
                cn.Close();
            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count>0)
            {


                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd = new SqlCommand("update cause set etat='non archivé', num_archive=NULL where id_cause='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت الارجاع بنجاح");

                cmd = new SqlCommand("select c.num_archive as[رقم الارشيف], c.id_cause as[المرجع],cl.nom as[الموكل],ad.nom_adv as[الخصم],c.num_cause_tribunal as[رقم القضية],c.date_session as[تاريخ الجلسة],c.ville as[المدينة],c.tribunal as[المحكمة] from cause c,client_cause cl,adversaire_cause ad where c.etat='archivé' and c.id_client=cl.id_client_cause and c.id_adv=ad.id_adversaire_cause order by date_session ASC", cn);
                dr = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dr.Fill(ds, "causes");
                dataGridView1.DataSource = ds.Tables["causes"];

                cn.Close();
            }
            else
            {

            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
