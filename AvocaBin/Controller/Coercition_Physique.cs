using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin.Controller;
using AvocaBin.Models;
using AvocaBin.Operation;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{
    public partial class Coercition_Physique : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        Coercition_PhysiqueOP op= new Coercition_PhysiqueOP();
        public Coercition_Physique()
        {
            InitializeComponent();
        }
        public void getDataFORgrid()
        {
            dataGridView1.Rows.Clear();
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM coercition_physique";
                cmd.Connection = cnx;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),dr[9].ToString());
                }
                dr.Close();
                cnx.Close();




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
        private void Coercition_Physique_Load(object sender, EventArgs e)
        {

            getDataFORgrid();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "موضوع")
            {
                comboBox2.Items.Clear();
                cmd = new SqlCommand("select id_cause from cause", cnx);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "id_cause");
                for (int i = 0; i < ds.Tables["id_cause"].Rows.Count; i++)
                {
                    comboBox2.Items.Add(ds.Tables["id_cause"].Rows[i][0].ToString());
                }
                ds.Tables["id_cause"].Rows.Clear();
                
            }
            if (comboBox1.Text == "أمر بالأداء")
            {
                comboBox2.Items.Clear();
                cmd = new SqlCommand("select id_order from orderr", cnx);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds1, "id_order");
                for (int i = 0; i < ds1.Tables["id_order"].Rows.Count; i++)
                {
                    comboBox2.Items.Add(ds1.Tables["id_order"].Rows[i][0].ToString());
                }
                ds1.Tables["id_order"].Rows.Clear();
            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_FormatStringChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            //if (cb_genre_plai.Text == "" || txb_name.Text == "")
            //{
            //    MessageBox.Show("المرجو ملا الخانات");
            //}
            //else
            //{
                CoercitionPhysique pp = new CoercitionPhysique();
                pp.N_dossier = comboBox2.SelectedItem.ToString();
                pp.Type_cause = comboBox1.SelectedItem.ToString();
                pp.Client = textBox1.Text;
                pp.Intime = textBox2.Text;
                pp.Ndossier_implement = textBox3.Text;
                pp.Tribune = textBox4.Text;
                pp.Ville = textBox5.Text;
                pp.Commissaire_juridique = textBox6.Text;
                pp.Date_application = dateTimePicker1.Value;

                op.addCoercitionPhysique(pp);

                getDataFORgrid();
                history.AddHistory("الإكراه البدني", "الاضافة", comboBox2.SelectedItem.ToString());
            //}
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) {

                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            }
        }
        public void cleartext()
        {
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void btn_nouveau_Click(object sender, EventArgs e)
        {
            cleartext();
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
                    op.deleteCoercitionPhysique(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    getDataFORgrid();

                    history.AddHistory("المشتكون", "الحدف", dataGridView1.CurrentRow.Cells[0].ToString());
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

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {

                CoercitionPhysique pp = new CoercitionPhysique();
                pp.N_coercition_physique = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                pp.N_dossier = (string)comboBox2.Text;
                pp.Type_cause = (string)comboBox1.Text;
                pp.Client = (string)textBox1.Text;
                pp.Intime = (string)textBox2.Text;
                pp.Ndossier_implement = (string)textBox3.Text;
                pp.Tribune = (string)textBox4.Text;
                pp.Ville = (string)textBox5.Text;
                pp.Commissaire_juridique = (string)textBox6.Text;
                pp.Date_application = (DateTime)dateTimePicker1.Value;
                op.updateCoercitionPhysique(pp);
                getDataFORgrid();
                
                //history.AddHistory("المشتكون", "التعديل", txb_cin.Text);
                cleartext();
            }
            else
            {
                MessageBox.Show("يجب اختيار مشتكي");
            }
        }

        private void txb_searsh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            // op.getParPlaignantByIdAndCIN(txb_searsh.Text);
            foreach (CoercitionPhysique pp in op.getSearchCphysique(txb_searsh.Text))
            {
                try
                {
                    dataGridView1.Rows.Add(pp.N_coercition_physique, pp.N_dossier, pp.Client, pp.Type_cause, pp.Tribune, pp.Ville, pp.Ndossier_implement,pp.Intime, pp.Commissaire_juridique);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txb_searsh.Clear();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PrintAllCorrectionForm frm = new PrintAllCorrectionForm();
            frm.Show();
        }
        
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string id;
            //int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //PrintOnlyOneCPhysique form = new PrintOnlyOneCPhysique(id);
            //form.Show();
            try
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                PrintOneCorrectionForm p = new PrintOneCorrectionForm();
                p.id = id;
                //p.idcoe = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                
               p.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
