using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AvocaBin;
using System.Data.SqlClient;

namespace AvocaBin.Controller
{

    public partial class tableau_Utilisateur : Form
    {
        //Cause_Operations co = new Cause_Operations();
        SqlConnection cn = connection.getConnection();
        DataSet ds;
        SqlCommand cmd;
        SqlDataAdapter dr;
        public tableau_Utilisateur()
        {
            InitializeComponent();
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
        private void tableau_Utilisateur_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand("select * from Utilisateur", cn);
            dr = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dr.Fill(ds, "utilisateurs");
            dataGridView1.DataSource = ds.Tables["utilisateurs"];
            cn.Close();
           // testdata();
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
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmdby;
                cmdby = new SqlCommandBuilder(dr);
                dr.Fill(ds, "utilisateurs");
                MessageBox.Show("Bien modifier", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
