using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AvocaBin.Operation;
using AvocaBin.Models.Plaintes;
using AvocaBin.Models;
using System.IO;

namespace AvocaBin
{
    public partial class Piéce_Joint_Plainte : DevExpress.XtraEditors.XtraForm
    {
        OpenFileDialog of;
        int u = 0;
        PlaintesOperations op;
        DataSet ds = new DataSet();
        SqlConnection cn = connection.getConnection();
        SqlDataAdapter ad;
        public Piéce_Joint_Plainte()
        {
            of = new OpenFileDialog();
            op = new PlaintesOperations();
            InitializeComponent();
        }
        public void getDataTable()
        {
            dataGridView1.Rows.Clear();
            List<PjPlainte> pp = op.getPJPlainte(textBoxIdPlainte.Text);



            foreach (PjPlainte ppj in pp)
            {
                MemoryStream photo = new MemoryStream(ppj.Photo);
                Image img = Image.FromStream(photo);

                dataGridView1.Rows.Add(ppj.Id_pj, ppj.Id_plainte, ppj.Titre,img);

            }
            testdata();
        }
        public void search_data()
        {
            if (textBoxIdPlainte.Text == "")
            {
                getDataTable();
            }
            else
            {
                dataGridView1.Rows.Clear();
                List<PjPlainte> pp = op.getPJPlainte(textBoxIdPlainte.Text);
                foreach (PjPlainte ppj in pp)
                {
                    MemoryStream photo = new MemoryStream(ppj.Photo);
                    Image img = Image.FromStream(photo);

                    dataGridView1.Rows.Add(ppj.Id_pj, ppj.Id_plainte, ppj.Titre,img);
                }
                testdata();
            }
        }
        private void Btn_searsh_Click(object sender, EventArgs e)
        {
            
            //if (textBoxIdPlainte.Text != "")
            //{
            //    getDataTable();

            //}
            //else
            //{
            //    MessageBox.Show("يجب ملئ خانة البحث , للبحث عن الشكايات");
            //}
            
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
        private void Piéce_Joint_Plainte_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Sultan Nahia", 12));
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            getDataTable();
            ad = new SqlDataAdapter("select id_plainte from plainte", cn);
            ad.Fill(ds, "id_plainte");

            comboBox1.DataSource = ds.Tables["id_plainte"];
            comboBox1.DisplayMember = "id_plainte";
            //getdata();
            
        }
        
        public void testdata()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                simpleButton3.Enabled = false;
                // btn_imprimer.Enabled = false;
            }
            else
            {
                simpleButton3.Enabled = true;
                // btn_imprimer.Enabled = true;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                pictureBox1.Image = (Image)dataGridView1.SelectedRows[0].Cells[3].Value;
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            of.Filter = "Images (*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.PNG;*.JPEG;*.GIF|" + "All files (*.*)|*.*";
            of.Title = "تحميل الصور :";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("تم تحميل الصورة");
                u = 1;
            }
            else
            {
                MessageBox.Show("لم تحميل الصورة");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //save PJ setup
            if (u == 1 && comboBox1.Text != "")
            {
                foreach (string fileName in of.FileNames)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(fileName);
                        PjPlainte pjplaint = new PjPlainte();
                        byte[] img = null;
                        FileStream f = new FileStream(of.FileName, FileMode.Open);
                        BinaryReader br = new BinaryReader(f);
                        img = br.ReadBytes((int)f.Length);
                        f.Close();


                        pjplaint.Id_plainte = comboBox1.Text;
                            pjplaint.Photo = img;

                        pjplaint.Titre = Path.GetFileName(of.FileName);
                        pjplaint.Date_enregistrement =DateTime.Parse( DateTime.Now.ToShortDateString());
                        //  pjOrder1.id_order = ord.id_order;
                        op.addPjPalainte(pjplaint);
                        MessageBox.Show("تمت إضافة الوثيقة بنجاح");
                        history.AddHistory("وثائق الشكاية", "الاضافة", comboBox1.Text);
                        getDataTable();
                        
                        
                       
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
                MessageBox.Show("يجب اختيار رقم الشكاية في خانة الشكايات لإضافة الوثيقة");
            }
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                op.deletePJplainte(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                history.AddHistory("وثائق الشكاية", "الحدف", textBoxIdPlainte.Text);
                getDataTable();
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show("الجدول غير ممتلئ");
            }
            
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBoxIdPlainte_TextChanged(object sender, EventArgs e)
        {
            search_data();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}