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
using AvocaBin.Models;

namespace AvocaBin.Controller
{
    public partial class FonctionSupprimer : Form
    {
        SqlConnection cnx = connection.getConnection();
        public FonctionSupprimer()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSupprimer.Text !="")
                {


                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "delete from Fonction where fonction='" + textBoxSupprimer.Text + "'";
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم حدف الوظيفة بنجاح", "الحدف", MessageBoxButtons.OK);
                    history.AddHistory("الوظيفة", "حدف", textBoxSupprimer.Text);

                    dataGridView1.Rows.Clear();
                    cmd.CommandText = "select * from Fonction";
                    cmd.Connection = cnx;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0].ToString());
                    }
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("يجب اختيار السطر المراد حدفه من جدول الوظائف","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
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
        private void FonctionSupprimer_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            dataGridView1.Rows.Clear();
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from fonction";
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

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            textBoxSupprimer.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBoxSupprimer.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

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
