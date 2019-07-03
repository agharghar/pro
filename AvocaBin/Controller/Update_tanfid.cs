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
    public partial class Update_tanfid : Form
    {
        SqlConnection cn = connection.getConnection();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        DataSet ds = new DataSet();
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        string id;
        public Update_tanfid(string id)
        {
            this.id = id;
            InitializeComponent();
        }
        public void getdata_tribunal()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                comboBox3.Items.Clear();
                cmd = new SqlCommand("select tribunal from tribunal", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tribunal");
                cn.Close();
                for (int i = 0; i < ds.Tables["tribunal"].Rows.Count; i++)
                {
                    comboBox3.Items.Add(ds.Tables["tribunal"].Rows[i][0].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            ds.Tables["tribunal"].Clear();

        }

        public void getdata_ville()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                comboBox5.Items.Clear();
                cmd = new SqlCommand("select ville from ville", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "ville");
                cn.Close();
                for (int i = 0; i < ds.Tables["ville"].Rows.Count; i++)
                {
                    comboBox5.Items.Add(ds.Tables["ville"].Rows[i][0].ToString());
                }
                ds.Tables["ville"].Clear();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

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
        private void Update_tanfid_Load(object sender, EventArgs e)
        {
            getdata_ville();
            getdata_tribunal();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            tribunalAjouter frm = new tribunalAjouter();
            frm.ShowDialog();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            VilleAjoute frm = new VilleAjoute();
            frm.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getdata_tribunal();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            getdata_ville();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            cmd = new SqlCommand("update tanfid set date_tanfide='" + dateTimePicker2.Value.ToShortDateString() + "',type_tanfid='" + textBox10.Text + "',tribunal='" + comboBox3.Text + "',typeCause='" + textBox11.Text + "',ville='" + comboBox5.Text + "',note='" + textBox7.Text + "' from tanfid  where num_tanfid='" + id + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
