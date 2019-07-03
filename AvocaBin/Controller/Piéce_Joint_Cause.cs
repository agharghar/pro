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
using AvocaBin.Operation;
using AvocaBin.Models.cause;
using System.Data.SqlClient;
using System.IO;
using AvocaBin.Controller;
using AvocaBin.Models;
namespace AvocaBin
{
    public partial class Piéce_Joint_Cause : DevExpress.XtraEditors.XtraForm
    {
        Cause_Operations co = new Cause_Operations();
        OpenFileDialog of;
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter ad;
        int u;

        public Piéce_Joint_Cause()
        {
            of = new OpenFileDialog(); 
            InitializeComponent();
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void getdata()
        {
            dataGridView1.Rows.Clear();
            List<PJ_cause> pp = co.getAllPieceJointe();
            foreach (PJ_cause ppj in pp)
            {
                MemoryStream photo = new MemoryStream(ppj.Photo);
                Image img = Image.FromStream(photo);

                dataGridView1.Rows.Add(ppj.Id_cause, ppj.Titre, img, ppj.Date_enregistrement.ToShortDateString(),ppj.Id_pj_cause);
            }
            testdata();
        }
        public void search_data() 
        {
            if (textBox1.Text == "")
            {
                getdata();
            }
            else
            {
                dataGridView1.Rows.Clear();
                List<PJ_cause> pp = co.getPJ_cause(textBox1.Text);
                foreach (PJ_cause ppj in pp)
                {
                    MemoryStream photo = new MemoryStream(ppj.Photo);
                    Image img = Image.FromStream(photo);

                    dataGridView1.Rows.Add(ppj.Id_cause, ppj.Titre, img, ppj.Date_enregistrement.ToShortDateString(), ppj.Id_pj_cause);
                }
                testdata();
            }
        }
        public void testdata()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                btn_delete.Enabled = false;
               // btn_imprimer.Enabled = false;
            }
            else
            {
                btn_delete.Enabled = true;
               // btn_imprimer.Enabled = true;
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
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void Piéce_Joint_Cause_Load(object sender, EventArgs e)
        {

            

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
                
            ad = new SqlDataAdapter("select id_cause from cause", cn);
            ad.Fill(ds, "id_cause");
            cb_num_cause.DataSource = ds.Tables["id_cause"];
            cb_num_cause.DisplayMember = "id_cause";
            getdata();
            label4.Visible = false;
            label5.Visible = true;
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Image img = (Image)dataGridView1.SelectedRows[0].Cells[2].Value;
                Byte[] data = new Byte[0];
                data = (Byte[])(ImageToByte(img));
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            getdata();
            textBox1.Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("تم تحميل الصورة");
                label4.Visible = true;
                label5.Visible = false;
                u = 1;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           //MessageBox.Show(DateTime.Today.ToString("d"));
           if (u == 1 && cb_num_cause.Text!="")
           {
               foreach (string fileName in of.FileNames)
               {
                   try
                   {
                       FileInfo fi = new FileInfo(fileName);
                       PJ_cause pjCause = new PJ_cause();
                       byte[] img = null;
                       FileStream f = new FileStream(of.FileName, FileMode.Open);
                       BinaryReader br = new BinaryReader(f);
                       img = br.ReadBytes((int)f.Length);
                       f.Close();
                       pjCause.Id_cause = cb_num_cause.Text;
                       pjCause.Photo = img;
                       
                       pjCause.Titre = Path.GetFileName(of.FileName);
                       pjCause.Date_enregistrement = DateTime.Parse(DateTime.Today.ToString("d"));
                       co.add_piece_jointe_cause(pjCause);
                       MessageBoxManager.OK = "حسنا";
                       MessageBoxManager.Register();
                       DialogResult dr = MessageBox.Show("تمت الاضافة بنجاح", "", MessageBoxButtons.OK);
                       history.AddHistory("وثائق القضية", "الاضافة", cb_num_cause.Text);
                       MessageBoxManager.Unregister();
                       label4.Visible = false;
                       label5.Visible = true;
                       getdata();
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                   }
               }
               u = 0;
           }
           else
           {
               MessageBoxManager.OK = "حسنا";
               MessageBoxManager.Register();
               DialogResult dr = MessageBox.Show("المرجو ملئ الحقول", "تنبيه", MessageBoxButtons.OK);
               MessageBoxManager.Unregister();
           }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
           // co = new Cause_Operations();
            MessageBoxManager.Yes = "نعم";
            MessageBoxManager.No = "لا";
            MessageBoxManager.Register();
            DialogResult dr = MessageBox.Show("هل أنت متأكد من الحذف ؟؟", "تنبيه", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();
            if (dr == DialogResult.Yes)
            {
                co.deletePieceJointe_cause(int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()));
                history.AddHistory("وثائق القضية", "الحذف", cb_num_cause.Text);
                getdata();
                textBox1.Clear();
            }
            else
            {

            }
            //MessageBox.Show(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
        }

        private void cb_num_cause_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_imprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
           // ImprimerPJCause frm = new ImprimerPJCause(id);
            //frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search_data();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}