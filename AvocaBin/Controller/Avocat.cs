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
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace AvocaBin.Controller
{
    public partial class Avocat : Form
    {
        string imagLocation = "";
        int a;
        SqlConnection cnx = connection.getConnection();
        public Avocat()
        {
            InitializeComponent();
        }

        private void معلوماتعناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProposNous p = new ProposNous();
            p.Show();
        }
        



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            SqlCommand cmdCount = new SqlCommand();
            cmdCount.Connection = cnx;
            cmdCount.CommandText = "select count(num_avocat) from avocat";
            cmdCount.CommandType = CommandType.Text;
            count = (int)cmdCount.ExecuteScalar();
            if (count == 1)
            {
                MessageBox.Show("لا يمكنك ادخال معلومات محامي جديدة . يجب عليك تعديل معلوماتك السابقة ... ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNomAvocat.Text != "" && txtAdresseAvocat.Text != "" && !(String.IsNullOrEmpty(imagLocation)) && txtAutoriteAvocat.Text != "")
                {
                    byte[] image = null;
                    FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    image = br.ReadBytes((int)stream.Length);
                    SqlParameter p1 = new SqlParameter("@nom_avocat", txtNomAvocat.Text);
                    SqlParameter p2 = new SqlParameter("@adress", txtAdresseAvocat.Text);
                    SqlParameter p3 = new SqlParameter("@autoriter", txtAutoriteAvocat.Text);
                    SqlCommand cmd = new SqlCommand("insert into avocat(num_avocat,nom_avocat,adresse,logo,autorite) values(1,@nom_avocat,@adress,@logo,@autoriter)");
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Connection = cnx;
                    cmd.Parameters.Add(new SqlParameter("@logo", image));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ثم ادخال المعلومات بنجاح");
                    cnx.Close();
                    GetDataAvocat();
                    clear();
                }
                else
                {
                    MessageBox.Show("يجب ملئ البيانات ");
                }
            }

        }

        private void btnDownLoadImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imagLocation = dlg.FileName.ToString();
                pictureBoxAvocat.ImageLocation = imagLocation;
            }


           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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
        private void Avocat_Load(object sender, EventArgs e)
        {
            
            try
            {
                GetDataAvocat();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        public void GetDataAvocat()
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            dataGridView2.Rows.Clear();
            SqlCommand cmdRead = new SqlCommand();
            cmdRead.Connection = cnx;
            cmdRead.CommandText = "select * from avocat";
            SqlDataReader dr = cmdRead.ExecuteReader();
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr["nom_avocat"].ToString(), dr["adresse"].ToString(), dr["autorite"].ToString());
                pictureBoxAvocat.Image = byteArrayToImage((byte[])dr["logo"]);
            }
            dr.Close();
            cnx.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
      

            

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
           
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                if (txtNomAvocat.Text != "" && txtAdresseAvocat.Text != "" && txtAutoriteAvocat.Text != "")
                {
                    byte[] image = null;
                    FileStream stream = new FileStream(imagLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    image = br.ReadBytes((int)stream.Length);
                    SqlCommand cmdUpdate = new SqlCommand();
                    cmdUpdate.CommandText = "UPDATE avocat SET  nom_avocat='" + txtNomAvocat.Text + "' , adresse='" + txtAdresseAvocat.Text + "' , logo=@logo , autorite='" + txtAutoriteAvocat.Text + "'  WHERE num_avocat = 1 ";
                    cmdUpdate.Connection = cnx;
                    cmdUpdate.Parameters.Add(new SqlParameter("@logo", image));
                    cmdUpdate.ExecuteNonQuery();
                    cnx.Close();
                    MessageBox.Show("التعديل ثم بنجاح", "التعديل", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    GetDataAvocat();
                    clear();
                }
                else
                {
                    MessageBox.Show("يجب اختيار المعلومات المراد التعديل عليها ة لايمكنك التعديل على الفراغ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.CommandText = "select logo from avocat";
            cmd.Connection = cnx;
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
            dr = cmd.ExecuteReader();
            dr.Read();
            pictureBoxAvocat.Image = byteArrayToImage((byte[])dr[0]);
            txtNomAvocat.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtAdresseAvocat.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtAutoriteAvocat.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dr.Close();
            cnx.Close();

        }
        public void clear() 
        {
            txtNomAvocat.Clear();
            txtAdresseAvocat.Clear(); 
            txtAutoriteAvocat.Clear();
            pictureBoxAvocat.Image = null;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count==1)
                {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM avocat WHERE num_avocat=1";
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ثم الحدف بنجاح ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnx.Close();
                GetDataAvocat();
                clear();
                }
                else
                {
                    MessageBox.Show("لا يمكنك الحدف , يجب اختيار المعلومات المراد حدفها ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}