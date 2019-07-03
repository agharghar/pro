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
using AvocaBin.Controller;
using AvocaBin.Models.TextJuridique;
using AvocaBin.Models;
namespace AvocaBin.Controller
{
    public partial class FonctionAjoute : Form
    {
        SqlConnection cnx = connection.getConnection();
        SqlCommand cmd = new SqlCommand();

        public FonctionAjoute()
        {
            InitializeComponent();
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            textBoxFonction.Clear();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxFonction.Text!="")
                {
                    if (cnx.State==ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    cmd.Connection = cnx;
                    cmd.CommandText = "insert into Fonction(fonction) values('"+textBoxFonction.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت الاظافة بنجاح");
                    history.AddHistory("الوظيفة", "اضافة", textBoxFonction.Text);
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









            //try
            //{
            //    if (textBoxFonction.Text == "")
            //    {
            //        MessageBox.Show("المرجو ملئ جميع الحقول");
            //    }
            //    else
            //    {
            //        if (DialogResult.Yes == MessageBox.Show("هل أنت متأكد من إضافة هذه المهنة ؟", "تنبيه", MessageBoxButtons.YesNo))
            //        {
            //            d.MiseAjour("INSERT INTO [dbo].[Fonction] VALUES ('" + textBoxFonction.Text + "')");
            //            MessageBox.Show("العملية تمت بنجاح");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
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
        private void FonctionAjoute_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
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
