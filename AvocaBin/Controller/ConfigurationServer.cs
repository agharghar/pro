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


namespace AvocaBin.Controller
{
    public partial class ConfigurationServer : Form
    {
        public ConfigurationServer()
        {
            InitializeComponent();
            txtServerName.Text = Properties.Settings.Default.Server;
            txtDBName.Text = Properties.Settings.Default.DataBase;
            if (Properties.Settings.Default.Mode=="SQL")
            {
                radioSQLAuth.Checked = true;
                txtUser.Text = Properties.Settings.Default.ID;
                txtPass.Text = Properties.Settings.Default.PassWord;
            }
            else
            {
                radioWindowsAuth.Checked = true;
                txtUser.Clear();
                txtPass.Clear();
                txtUser.ReadOnly = true;
                txtPass.ReadOnly = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void معلوماتعناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProposNous p = new ProposNous();
                p.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من التعديل .. ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                Properties.Settings.Default.Server = txtServerName.Text;
                Properties.Settings.Default.DataBase = txtDBName.Text;
                Properties.Settings.Default.Mode = radioSQLAuth.Checked == true ? "SQL" : "Windows";
                Properties.Settings.Default.ID = txtUser.Text;
                Properties.Settings.Default.PassWord = txtPass.Text;
                Properties.Settings.Default.Save();
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult d = MessageBox.Show("لقد ثم التعديل ", "تنبيه", MessageBoxButtons.OK,MessageBoxIcon.Information);
                MessageBoxManager.Unregister();                
            }
            else
            {
                this.Close();
            }

        }

        private void radioSQLAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.ReadOnly = false;
            txtPass.ReadOnly = false;
        }

        private void radioWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.ReadOnly = true;
            txtPass.ReadOnly = true;
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
        private void ConfigurationServer_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
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
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
