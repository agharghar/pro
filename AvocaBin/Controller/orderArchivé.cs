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
using AvocaBin.Models;

namespace AvocaBin.Controller
{
    public partial class orderArchivé : Form
    {
        public orderArchivé()
        {
            InitializeComponent();
        }

        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        string id, cin, d1, d2;

        private void refresh()
        {
            SqlDataReader dr;
            DataTable dt = new DataTable();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select o.num_archive,o.id_order,o.signe_order,o.date_order,o.commissaire_judiciaire,o.ville,o.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',o.decision,o.type from orderr o,client_order c,adv_order a where o.etat='archivé' and o.id_client_order=c.id_client_order and o.id_adversaire_order=a.id_adv_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            cn.Close();
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
        private void orderArchivé_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            refresh();
        }

        private void btn_searsh_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_searsh_Click_1(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحدف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    int r = order.delete(id);
                    if (r == 1) { MessageBox.Show("تم الحدف بنجاح"); }
                    else { MessageBox.Show("الرجاء إعادة المحاولة"); }
                    history.AddHistory("الأمر", "حدف", id);
                    refresh();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error : " + ee);
                }
            }
            else
            { }
        }

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            try
            {
                PrintOneOrderForm p = new PrintOneOrderForm();
                p.idOrder = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlConnection cn = connection.getConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select id_client_order,id_adversaire_order from orderr where id_order=@id";
                cmd.Parameters.Add("@id", p.idOrder);
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                dr = cmd.ExecuteReader();
                dr.Read();
                p.idcli = (int)dr["id_client_order"];
                p.idadv = (int)dr["id_adversaire_order"];
                dr.Close();
                cn.Close();
                p.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btn_imprimerAll_Click(object sender, EventArgs e)
        {
            PrintAllOrdersForm p = new PrintAllOrdersForm();
            p.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            if (dataGridView1.Rows.Count>0)
            {
                cmd = new SqlCommand("update orderr set etat='non archivé',num_archive=NULL where id_order='" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت الارجاع بنجاح");
                cn.Close();
                refresh();

            }
            else
            {

            }
            
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                id = textBox1.Text;
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                DataTable dt = new DataTable();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select distinct ord.num_archive,ord.id_order,ord.signe_order,ord.date_order,ord.commissaire_judiciaire,ord.ville,ord.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',ord.decision,ord.type from orderr ord,client_order c,adv_order a where (ord.id_order = @id or ord.num_archive=@id) and ord.etat='archivé' and ord.id_adversaire_order=a.id_adv_order and ord.id_client_order=c.id_client_order";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@num", id);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                cn.Close();
                cmd.Parameters.Clear();
                if (textBox1.Text=="")
                {
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cin = textBox2.Text;

                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                DataTable dt = new DataTable();
                SqlDataReader dr;
                cmd.Connection = cn;
                cmd.CommandText = "select ord.num_archive,ord.id_order,ord.signe_order,ord.date_order,ord.commissaire_judiciaire,ord.ville,ord.tribunal,c.nom as 'id_client_order',a.nom as 'id_adversaire_order',ord.decision,ord.type from orderr ord,client_order c,adv_order a where ord.etat='archivé' and ord.id_adversaire_order=a.id_adv_order and ord.id_client_order=c.id_client_order and c.nom = @cin";
                cmd.Parameters.AddWithValue("@cin", cin);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
                cn.Close();
                cmd.Parameters.Clear();
                if (textBox2.Text == "")
                {
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
