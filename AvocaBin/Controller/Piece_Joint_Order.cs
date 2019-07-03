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
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using AvocaBin.Models;

namespace AvocaBin
{
    public partial class Piece_Joint_Order : DevExpress.XtraEditors.XtraForm
    {
        public Piece_Joint_Order()
        {
            InitializeComponent();
        }

        OpenFileDialog of = new OpenFileDialog();
        int u = 0;
        SqlConnection cn = connection.getConnection();

        private void refresh()
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from PJ_order";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            cn.Close();
            dr.Dispose();



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
        private void Piece_Joint_Order_Load(object sender, EventArgs e)
        {

        
            refresh();
            SqlConnection cn = connection.getConnection();
            string query = "select * from orderr";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "order");
            cb_num_cause.DisplayMember = "id_order";
            cb_num_cause.ValueMember = "id_order";
            cb_num_cause.DataSource = ds.Tables["order"];
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
        private void Btn_searsh_Click(object sender, EventArgs e)
        {
            
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Image img = byteArrayToImage((byte[])dataGridView1.CurrentRow.Cells[1].Value);
            pictureBox1.Image = img;
        }

        private void Btn_Aficher_Tous_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btn_telecharger_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                u = 1;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //save
            if (u == 1 && cb_num_cause.Text != "")
            {
                foreach (string fileName in of.FileNames)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(fileName);
                        PjOrder pjOrder1 = new PjOrder();
                        byte[] img = null;
                        FileStream f = new FileStream(of.FileName, FileMode.Open);
                        BinaryReader br = new BinaryReader(f);
                        img = br.ReadBytes((int)f.Length);
                        f.Close();
                        pjOrder1.photo = img;
                        pjOrder1.titre = Path.GetFileName(of.FileName);
                        pjOrder1.date_enregistrement = DateTime.Now.ToShortDateString();
                        pjOrder1.id_order = (string)cb_num_cause.SelectedValue ;
                        int id = pjOrder1.save();
                        history.AddHistory("وثائق الامر", "إضافة", id.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                MessageBox.Show("تمت الإضافة بنجاح");
                u = 0;
            }
            else
            {
                MessageBox.Show("يجب ملئ الخانات");
            }
        }
        public void deletePieceJointe_Order(int id_pj)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE FROM PJ_order WHERE id_pj=" + id_pj, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحدف بنجاح ");
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                int a = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                deletePieceJointe_Order(a);

            }
            else
            {
                MessageBox.Show("يجب ملئ خانة البحث");
            }
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                refresh();
            else
            {
                string order = textBox1.Text;
                List<PjOrder> list = PjOrder.findOrderPj(order);
                dataGridView1.DataSource = list;
                dataGridView1.Refresh();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }
        
        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       




    }
}