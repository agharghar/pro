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
    public partial class TableHistory : Form
    {
        public TableHistory()
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
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void TableHistory_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection cnx = connection.getConnection();
                SqlDataReader dr;
                cmd.Connection = cnx;
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.CommandText = "select * from history";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(),dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
                dr.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
