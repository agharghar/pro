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
using AvocaBin.Controller;
using AvocaBin.Models;
using AvocaBin.Models.TextJuridique;
using System.Data.SqlClient;

namespace AvocaBin
{
    public partial class Creation_Des_Compte : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cnx = connection.getConnection();
        
        public Creation_Des_Compte()
        {
            InitializeComponent();
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

        private void BtnCompteSortie_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCompteCreation_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (txtCIN.Text == "" || txtNOM.Text == "" || txtPRE.Text == "" || txtMOTPASS.Text == "" || cmbFonction.SelectedIndex == -1)
                {
                    MessageBox.Show("المرجو ملئ جميع الحقول");
                }
                else
                {
                    SqlCommand CmdAjout = new SqlCommand();
                    CmdAjout.Connection = cnx;
                    CmdAjout.CommandText = "insert into Utilisateur values ('" + txtCIN.Text + "' , '" + txtNOM.Text + "' , '" + txtPRE.Text + "' , '" + txtMOTPASS.Text + "' , GETDATE () , '" + cmbFonction.Text + "')";
                    CmdAjout.ExecuteNonQuery();
                    MessageBox.Show("ثم اضافة المستخدم بنجاح", "المستخدم",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    cnx.Close();
                }               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
        
        //private void panel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    mouseDown = true;
        //}

        //private void panel1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (mouseDown)
        //    {
        //        mouseX = MousePosition.X - 400;
        //        mouseY = MousePosition.Y - 40;
        //        this.SetDesktopLocation(mouseX, mouseY);
        //    }
        //}

        //private void panel1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    mouseDown = false;
        //}
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void Creation_Des_Compte_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.Connection = cnx;
                cmd.CommandText = "select fonction from Fonction";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbFonction.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cnx.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbFonction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}