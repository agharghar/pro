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

using AvocaBin.Controller;



using System.Data.SqlClient;namespace AvocaBin
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        SqlConnection cn = connection.getConnection();
        //Login lg = new Login();
        public Login()
        {
            
            InitializeComponent();
        }

        private void Login_Enter(object sender, EventArgs e)
        {
            
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
        private void Login_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnConx_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnConx_Click_1(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd = new SqlCommand("select *from utilisateur where cin='" + txtbxCIN.Text + "' and ModePasse='" + txtbxPasse.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (txtbxCIN.Text == "avocabine" && txtbxPasse.Text == "avocabine")
            {
                this.Hide();
                FormMain f = new FormMain();
                f.barButtonItem37.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                f.Show();
               
            }

            else
            {
                if (dr.HasRows)
                {
                    //MessageBox.Show("ok");
                    this.Hide();

                    FormMain f = new FormMain();
                    f.Show();
                    //this.Close();
                    dr.Close();
                    
                    
                }
                else
                {
                    MessageBox.Show("رقم البطاقة الوطنية أو كلمة السر غير صحيحة !!!");
                }

            }
            dr.Close();
            cn.Close();
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelCréerCompte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Creation_Des_Compte c = new Creation_Des_Compte();
            c.Show();
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            txtbxCIN.Clear();
        }

        private void dropDownButton2_Click(object sender, EventArgs e)
        {
            txtbxPasse.Clear();
        }

        private void linkLabelOublieMotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigurationServer c = new ConfigurationServer();
            c.Show();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}