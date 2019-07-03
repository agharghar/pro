using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using AvocaBin.Controller;
using System.Net.Sockets;
using System.Globalization;

namespace AvocaBin.Controller
{
    public partial class Activation : Form
    {
        public Activation()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSerial.Text == GetSerial.GetSerialNumber())
                {
                    string pathString;
                    pathString = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\dll\";

                    System.IO.Directory.CreateDirectory(pathString);
                    System.IO.File.WriteAllBytes(pathString + "ver.txt", new byte[0]);
                    TextWriter tw = new StreamWriter(pathString + "ver.txt");
                    tw.WriteLine(txtSerial.Text);
                    tw.Close();

                    DateTime localDateTime = DateTime.Now;
                    //bool test = false;
                    //while (test == false)
                    //{
                    //    try
                    //    {
                    //        TcpClient client = new TcpClient();
                    //        client.Connect("time.nist.gov", 13);
                    //        StreamReader streamReader = new StreamReader(client.GetStream());
                    //        var response = streamReader.ReadToEnd();
                    //        if (response.Length != 0)
                    //        {
                    //            var utcDateTimeString = response.Substring(7, 17);
                    //            localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    //            test = true;
                    //        }
                    //    }
                    //    catch (Exception ee)
                    //    {
                    //        if (ee is SocketException || ee is IOException) { }
                    //    }
                    //}

                    Properties.Settings.Default.DateInisial = localDateTime;
                    DateTime dt1 = localDateTime;
                    TimeSpan oneDay = TimeSpan.FromDays(365);
                    DateTime demain = dt1 + oneDay;
                    Properties.Settings.Default.DateFinal = demain;
                    Properties.Settings.Default.Save();
                    
                    MessageBox.Show("ثم التفعيل بنجاح ", " البرنامج مفعل ... سينتهي البرنامج في " + DateExpiration.DateExpirationAvocaBine().ToString() + " ");

                }
                else
                {
                    MessageBox.Show("الكود غير صحيح ، تأكد من الكود", "فشل المحاولة");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.avocabine.com");
            string dd;
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
        private void Activation_Load(object sender, EventArgs e)
        {
            
        }

        
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
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
