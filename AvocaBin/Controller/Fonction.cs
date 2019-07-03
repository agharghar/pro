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
using AvocaBin.Models.TextJuridique;


namespace AvocaBin.Controller
{
    public partial class Fonction : Form
    {
        SqlConnection cnx = connection.getConnection();
        public Fonction()
        {
            InitializeComponent();
        }

        private void LesVille_Click(object sender, EventArgs e)
        {
            FonctionAjoute fa = new FonctionAjoute();
            fa.Show();
        }

        private void الحدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FonctionSupprimer fs = new FonctionSupprimer();
            fs.Show();
        }

        

        private void الخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void معلوماتعناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProposNous p = new ProposNous();
            p.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    dataGridView1.Rows.Clear();
            //    cnx.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "select * from fonction";
            //    cmd.Connection = cnx;
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        dataGridView1.Rows.Add(dr[0].ToString());
            //    }
            //    cnx.Close();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
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

        private void Fonction_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Droid Arabic Kufi", 9));
            try
            {
                //d.RemplirGridView("select fonction as 'الوظيفة'  from Fonction", "fonction", dataGridView1);
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Fonction ";
                cmd.Connection = cnx;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString());
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            try
            {
                
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Fonction ";
                cmd.Connection = cnx;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString());
                }
                dr.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
