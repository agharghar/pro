using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AvocaBin.Controller;
using AvocaBin.Models.TextJuridique;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Web;

namespace AvocaBin.Controller
{
    public partial class TextJuridique : Form
    {

        public TextJuridique()
        {
            InitializeComponent();
        }
        public static string chemin;
        public static string cheminWord;
        public static string NomFichier;
        public static string NomFichierWord;
        public static string cheminWordToPdf;
        public static string aa;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
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
        
        private void TextJuridique_Load(object sender, EventArgs e)
        {
            
            try
            {
                string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Pdf");
                for (int i = 0; i < files.Count(); i++)
                {
                    this.comboBox1.Items.Add(files[i].GetCharsBetween("\\Pdf\\", ".pdf").ToString());
                }
                string[] filess = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\docx");
                for (int i = 0; i < filess.Count(); i++)
                {

                    this.comboBox2.Items.Add(filess[i].GetCharsBetween("\\docx\\", ".doc").ToString());
                }
                
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message) ;
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("Pdf\\"+comboBox1.SelectedItem.ToString()+".pdf", FileMode.Open, FileAccess.Read);
                pdfViewer1.LoadDocument(fs);
                pdfViewer1.Refresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                FileStream fs = new FileStream("docx\\"+comboBox2.SelectedItem.ToString()+".doc", FileMode.Open, FileAccess.Read);
                //pdfViewer1.LoadDocument(fs);
                //pdfViewer1.Refresh();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "docx\\" + comboBox2.SelectedItem.ToString() + ".doc";
                proc.Start();
                proc.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            try
            {
                FileStream fs = new FileStream("docx\\" + comboBox2.SelectedItem.ToString() + ".docx", FileMode.Open, FileAccess.Read);
                //pdfViewer1.LoadDocument(fs);
                //pdfViewer1.Refresh();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "docx\\" + comboBox2.SelectedItem.ToString() + ".docx";
                proc.Start();
                proc.Close();
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message);
            }

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }



        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void axAcroPDF1_Enter_1(object sender, EventArgs e)
        {

        }

        private void معلوماتعناToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProposNous p = new ProposNous();
            p.Show();
            }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {                    }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
