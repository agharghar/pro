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
using AvocaBin.Models;

namespace AvocaBin
{
    public partial class VilleAjoute : Form
    {
        SqlConnection cnx = connection.getConnection();
        public VilleAjoute()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {


                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "insert into ville(ville) values(@ville)";
                    SqlParameter p = new SqlParameter("@ville", textBox1.Text);
                    cmd.Parameters.Add(p);
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم اظافة المدينة بنجاح", "الاظافة", MessageBoxButtons.OK);
                    history.AddHistory(" المحكمة", "الاظافة", textBox1.Text);
                    cnx.Close();
                }
                else
                {
                            MessageBox.Show("يجب ملا الخانة");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
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
        private void VilleAjoute_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Droid Arabic Kufi", 9));
        }

        private void simpleButton7_Click(object sender, EventArgs e)
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
