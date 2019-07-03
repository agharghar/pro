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

namespace AvocaBin.Controller
{
    public partial class ProposNous : Form
    {
        public ProposNous()
        {
            InitializeComponent();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProposNous_Load(object sender, EventArgs e)
        {
            label5.Text = "تاريخ الانتهاء "+Properties.Settings.Default.DateFinal.ToShortDateString();
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
