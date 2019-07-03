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

namespace AvocaBin.Controller
{
    public partial class ListeVille : Form
    {
        SqlConnection cnx = connection.getConnection();
        public ListeVille()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LesVille_Click(object sender, EventArgs e)
        {
            VilleAjoute v = new VilleAjoute();
            v.Show();
        }

        private void الحدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VilleSupprimer vs = new VilleSupprimer();
            vs.Show();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dataGridView1.Rows.Clear();
                cmd.CommandText = "select * from ville";
                cmd.Connection = cnx;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString());
                }
                cnx.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void ListeVille_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            dataGridView1.Rows.Clear();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnx;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                dataGridView1.Rows.Clear();
                cmd.CommandText = "select * from ville";
                cmd.Connection = cnx;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString());
                }
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
