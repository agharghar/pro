using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AvocaBin.Controller;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using AvocaBin.Models.TextJuridique;
using DevExpress.XtraBars.Alerter;
using System.Collections;


namespace AvocaBin
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection cnx = connection.getConnection();
        SqlDataReader dr;

        public FormMain()
        {
            int CountCause = 0;
            try
            {
                if (cnx.State==ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.Connection = cnx;
                cmd.CommandText = "select count(id_cause) from cause";
                CountCause = (int)cmd.ExecuteScalar();
                DevExpress.XtraBars.BarStaticItem CountCauseResult = new DevExpress.XtraBars.BarStaticItem();
                CountCauseResult.Caption = CountCause.ToString();
                CountCauseResult.Caption.Equals(CountCause.ToString());
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Login lg = new Login();
            lg.Close();

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
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

            string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Dashboard");
            FileStream fs = new FileStream("Dashboard\\" + "FormMainDashBoard" + ".xml", FileMode.Open, FileAccess.Read);
            dashboardViewer1.LoadDashboard(fs);
            dashboardViewer1.Refresh();
            
            //DevExpress.XtraBars.Ribbon.RibbonStatusBar.DefaultForeColor

            //------------------------------------

            try
            {
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                
                DateTime DateDesition;
                int Delai = 0;
                DateTime DateMoment = DateTime.Now;
                int Constante = 5;
                DateTime DateFin;
                DateTime NotificationDay;
                SqlDataReader dr2;
                SqlDataReader dr1;
                cmd.Connection = cnx;
                cmd.CommandText = "select id_cause,duree from cause ";
                dr1 = cmd.ExecuteReader();
                bool show = false;

                while (dr1.Read())
                {
                    Delai = Convert.ToInt32(dr1[1].ToString());
                    

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cnx;
                    cmd2.CommandText = "select date_session,decision from sessione where id_cause='" + dr1[0].ToString() + "' and (decision='مداولة' or decision='المداولة')";
                    dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        DateDesition = (DateTime)dr2[0];
                        DateFin = DateDesition.AddDays(Delai);
                        NotificationDay = DateFin.AddDays(-5);
                        if (DateMoment.Day >= NotificationDay.Day)
                        {
                            show = true;
                            
                        }
                        
                    }
                    dr2.Close();
                }
                    dr1.Close();
                    cnx.Close();
                    if (show==true)
                    {
                        alertControl1.AutoFormDelay = 5000;
                            alertControl1.ShowPinButton = true;
                            alertControl1.ShowCloseButton = true;
                            alertControl1.LookAndFeel.SetStyle3D();
                            alertControl1.Show(this, "هناك قضايا أجالاتها قريبة الانتهاء ", "المرجوا الدهاب الى جدول الاجالات  ");
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //-------------------------------------
            DateTime datenow = DateTime.Now;
            
            //String fileContent;
            //string pathString;
            //pathString = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\dll\";

            //fileContent = System.IO.File.ReadLines(pathString + "ver.txt").First();
            //if (fileContent == GetSerial.GetSerialNumber())
            //{
            //    if (Properties.Settings.Default.DateInisial <= datenow && Properties.Settings.Default.DateFinal >= datenow)
            //    {
            //        barButtonItem2.Enabled = true;
            //        barButtonItem3.Enabled = true;
            //        barButtonItem4.Enabled = true;
            //        ادارة.Enabled = true;
            //        barButtonItem6.Enabled = true;
            //        barButtonItem5.Enabled = true;
            //        ezsffdsfdsfsd.Enabled = true;
            //        barButtonItem9.Enabled = true;
            //        barButtonItem10.Enabled = true;
            //        barButtonItem11.Enabled = true;
            //        barButtonItem12.Enabled = true;
            //        barButtonItem16.Enabled = true;
            //        barButtonItem17.Enabled = true;
            //        barButtonItem18.Enabled = true;
            //        barButtonItem19.Enabled = true;
            //        barButtonItem20.Enabled = true;
            //        barButtonItem23.Enabled = true;
            //        barButtonItem24.Enabled = true;
            //        barButtonItem25.Enabled = true;
            //        barButtonItem33.Enabled = true;
            //        barButtonItem27.Enabled = true;
            //        barButtonItem28.Enabled = true;
            //        barButtonItem31.Enabled = true;
            //        barButtonItem31.Enabled = true;
            //        barButtonItem32.Enabled = true;
            //        barButtonItem14.Enabled = true;
            //        barButtonItem31.Enabled = true;
            //        barButtonItem35.Enabled = true;
            //        barButtonItem36.Enabled = true;
            //        barButtonItem15.Enabled = true;
            //        barButtonItem26.Enabled = true;
            //        barButtonItem38.Enabled = true;
            //        barButtonItem39.Enabled = true;
            //        barButtonItem30.Enabled = true;
            //        accordionControlElement20.Enabled = true;
            //        barButtonItem40.Enabled = true;
            //    }

            //    else
            //    {
            //        MessageBox.Show("البرنامج غير مفعل / يرجى الدهاب الى الاعدادات لتفعيل البرنامج", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //this.Close();
            //        barButtonItem2.Enabled = false;
            //        barButtonItem3.Enabled = false;
            //        barButtonItem4.Enabled = false;
            //        ادارة.Enabled = false;
            //        barButtonItem6.Enabled = false;
            //        barButtonItem5.Enabled = false;
            //        ezsffdsfdsfsd.Enabled = false;
            //        barButtonItem9.Enabled = false;
            //        barButtonItem10.Enabled = false;
            //        barButtonItem11.Enabled = false;
            //        barButtonItem12.Enabled = false;
            //        barButtonItem16.Enabled = false;
            //        barButtonItem17.Enabled = false;
            //        barButtonItem18.Enabled = false;
            //        barButtonItem19.Enabled = false;
            //        barButtonItem20.Enabled = false;
            //        barButtonItem23.Enabled = false;
            //        barButtonItem24.Enabled = false;
            //        barButtonItem29.Enabled = false;
            //        barButtonItem25.Enabled = false;
            //        barButtonItem33.Enabled = false;
            //        barButtonItem27.Enabled = false;
            //        barButtonItem28.Enabled = false;
            //        barButtonItem31.Enabled = false;
            //        barButtonItem31.Enabled = false;
            //        barButtonItem32.Enabled = false;
            //        barButtonItem14.Enabled = false;
            //        barButtonItem30.Enabled = false;
            //        hg.Enabled = false;
            //        accordionControlElement5.Enabled = false;
            //        accordionControlElement9.Enabled = false;
            //        accordionControlElement10.Enabled = false;
            //        barButtonItem31.Enabled = true;
            //        accordionControlElement2.Enabled = false;
            //        accordionControlElement3.Enabled = false;
            //        accordionControlElement4.Enabled = false;
            //        accordionControlElement1.Enabled = false;
            //        accordionControlElement12.Enabled = false;
            //        accordionControlElement13.Enabled = false;
            //        accordionControlElement6.Enabled = false;
            //        accordionControlElement7.Enabled = false;
            //        accordionControlElement8.Enabled = false;
            //        accordionControlElement14.Enabled = false;
            //        accordionControlElement15.Enabled = false;
            //        accordionControlElement16.Enabled = false;
            //        accordionControlElement17.Enabled = false;
            //        accordionControlElement18.Enabled = false;
            //        accordionControlElement19.Enabled = false;
            //        barButtonItem35.Enabled = false;
            //        barButtonItem36.Enabled = false;
            //        barButtonItem15.Enabled = false;
            //        barButtonItem26.Enabled = false;
            //        barButtonItem38.Enabled = false;
            //        barButtonItem39.Enabled = false;
            //        barButtonItem30.Enabled = false;
            //        accordionControlElement20.Enabled = false;
            //        barButtonItem40.Enabled = false;
            //        Activation ac = new Activation();
            //        ac.Show();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("البرنامج غير مفعل / يرجى الدهاب الى الاعدادات لتفعيل البرنامج", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //this.Close();
            //    barButtonItem2.Enabled = false;
            //    barButtonItem3.Enabled = false;
            //    barButtonItem4.Enabled = false;
            //    ادارة.Enabled = false;
            //    barButtonItem6.Enabled = false;
            //    barButtonItem5.Enabled = false;
            //    ezsffdsfdsfsd.Enabled = false;
            //    barButtonItem9.Enabled = false;
            //    barButtonItem10.Enabled = false;
            //    barButtonItem11.Enabled = false;
            //    barButtonItem12.Enabled = false;
            //    barButtonItem16.Enabled = false;
            //    barButtonItem17.Enabled = false;
            //    barButtonItem18.Enabled = false;
            //    barButtonItem19.Enabled = false;
            //    barButtonItem20.Enabled = false;
            //    barButtonItem23.Enabled = false;
            //    barButtonItem24.Enabled = false;
            //    barButtonItem29.Enabled = false;
            //    barButtonItem25.Enabled = false;
            //    barButtonItem33.Enabled = false;
            //    barButtonItem27.Enabled = false;
            //    barButtonItem28.Enabled = false;
            //    barButtonItem31.Enabled = false;
            //    barButtonItem31.Enabled = false;
            //    barButtonItem32.Enabled = false;
            //    barButtonItem14.Enabled = false;
            //    barButtonItem30.Enabled = false;
            //    hg.Enabled = false;
            //    accordionControlElement5.Enabled = false;
            //    accordionControlElement9.Enabled = false;
            //    accordionControlElement10.Enabled = false;
            //    barButtonItem31.Enabled = true;
            //    accordionControlElement2.Enabled = false;
            //    accordionControlElement3.Enabled = false;
            //    accordionControlElement4.Enabled = false;
            //    accordionControlElement1.Enabled = false;
            //    accordionControlElement12.Enabled = false;
            //    accordionControlElement13.Enabled = false;
            //    accordionControlElement6.Enabled = false;
            //    accordionControlElement7.Enabled = false;
            //    accordionControlElement8.Enabled = false;
            //    accordionControlElement14.Enabled = false;
            //    accordionControlElement15.Enabled = false;
            //    accordionControlElement16.Enabled = false;
            //    accordionControlElement17.Enabled = false;
            //    accordionControlElement18.Enabled = false;
            //    accordionControlElement19.Enabled = false;
            //    barButtonItem35.Enabled = false;
            //    barButtonItem36.Enabled = false;
            //    barButtonItem15.Enabled = false;
            //    barButtonItem26.Enabled = false;
            //    barButtonItem38.Enabled = false;
            //    barButtonItem39.Enabled = false;
            //    barButtonItem30.Enabled = false;
            //    accordionControlElement20.Enabled = false;
            //    barButtonItem40.Enabled = false;
            //    Activation ac = new Activation();
            //    ac.Show();
            //}
        }

        private void barDockingMenuItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barDockingMenuItem2_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }


        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                الموضوع m = new الموضوع();
                m.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                شكاية c = new شكاية();
                c.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ادارة_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ادارة_الموكلين i = new ادارة_الموكلين();
            i.ShowDialog();

        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ادارة_الخصوم ia = new ادارة_الخصوم();
            ia.ShowDialog();
        }

        
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            الجلسات j = new الجلسات();
            j.ShowDialog();
          
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            اليومية y = new اليومية();
            y.ShowDialog();
        }
        دليل_الهاتف dh;
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dh = new دليل_الهاتف();
            dh.ShowDialog();
        }
        private void ezsffdsfdsfsd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            المشتكون al = new المشتكون();
            al.ShowDialog();
        }



        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            المشتكون_بهم nm = new المشتكون_بهم();

            nm.ShowDialog();
        }

      
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            ادارة_موكلي_الامر tir = new ادارة_موكلي_الامر();
           
            tir.ShowDialog();
           
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ادارة_خصوم_الامر tmr = new ادارة_خصوم_الامر();
        
            tmr.ShowDialog();
          
        }

       

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Wadiaa w = new Wadiaa();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            جدول_القضايا l = new جدول_القضايا();

            l.ShowDialog();
            
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            جدول_الشكايات lt = new جدول_الشكايات();
            
            lt.ShowDialog();
           
        }

      

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            جدول_الاوامر lr = new جدول_الاوامر();
           
            lr.ShowDialog();
         
        }

      

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Piéce_Joint_Cause pjc = new Piéce_Joint_Cause();
            pjc.ShowDialog();
        }



        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                  
            Piéce_Joint_Plainte pjp = new Piéce_Joint_Plainte();
            
            pjp.ShowDialog();
           
        }

       

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            Piece_Joint_Order pjo = new Piece_Joint_Order();
        
            pjo.ShowDialog();
        
        }


        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Tableau_Des_RDV t = new Tableau_Des_RDV();
                t.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      


        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tableau_Des_RDV tableau_RDV = new Tableau_Des_RDV();
            tableau_RDV.ShowDialog();
        }

        

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }

        private void barStaticItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barStaticItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            
            ادارة_الموكلين i = new ادارة_الموكلين();
           
            i.ShowDialog();
        
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            
            ادارة_الخصوم ia = new ادارة_الخصوم();
        
            ia.ShowDialog();
      
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
          
            الجلسات j = new الجلسات();
          
            j.ShowDialog();
         
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            جدول_القضايا l = new جدول_القضايا();
          
            l.ShowDialog();
          
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            Piéce_Joint_Cause pjc = new Piéce_Joint_Cause();
            pjc.ShowDialog();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            المشتكون al = new المشتكون();
       
            al.ShowDialog();
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            المشتكون_بهم nm = new المشتكون_بهم();
         
            nm.ShowDialog();
         
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            جدول_الشكايات lt = new جدول_الشكايات();
          
            lt.ShowDialog();
        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {
            Piéce_Joint_Plainte pjp = new Piéce_Joint_Plainte();
          
            pjp.ShowDialog();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            ادارة_موكلي_الامر tir = new ادارة_موكلي_الامر();
         
            tir.ShowDialog();
        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
           
            ادارة_خصوم_الامر tmr = new ادارة_خصوم_الامر();
        
            tmr.ShowDialog();
     
            
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
           
            جدول_الاوامر lr = new جدول_الاوامر();
            
            lr.ShowDialog();
           
        }

        private void accordionControlElement18_Click(object sender, EventArgs e)
        {
           
            Piece_Joint_Order pjo = new Piece_Joint_Order();
            
            pjo.ShowDialog();
            
        }

        private void accordionControlElement19_Click(object sender, EventArgs e)
        {

            
            اليومية y = new اليومية();
            y.ShowDialog();
           
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Activation a = new Activation();
                a.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraUserControl1_Load(object sender, EventArgs e)
        {
            Activation a = new Activation();
            a.ShowDialog();
        }

        ConfigurationServer cs;
        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                cs = new ConfigurationServer();
                cs.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        المصاريف xxxxx;
        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            
            المصاريف xxxxx = new المصاريف();
            xxxxx.ShowDialog();
        }

        void xxxxx_FormClosed(object sender, FormClosedEventArgs e)
        {
            xxxxx = null;
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            الأمر a = new الأمر();
            a.ShowDialog();
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AvocaBin.Controller.TextJuridique t = new AvocaBin.Controller.TextJuridique();
            t.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Creation_Des_Compte cq = new Creation_Des_Compte();
            cq.ShowDialog();
        }

        private void accordionControlElement20_Click(object sender, EventArgs e)
        {
            AjalatForm a = new AjalatForm();
            a.ShowDialog();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Avocat a = new Avocat();
            a.ShowDialog();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListeVille l = new ListeVille();
            l.ShowDialog();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            دليل_الهاتف d = new دليل_الهاتف();
            d.ShowDialog();
        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tableau_Des_RDV t = new Tableau_Des_RDV();
            t.ShowDialog();
        }

        private void barButtonItem29_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProposNous pr = new ProposNous();
            pr.ShowDialog();
        }

        private void barButtonItem30_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cause_archivé tb = new cause_archivé();
            tb.ShowDialog();
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tableau_Utilisateur tb = new tableau_Utilisateur();
            tb.ShowDialog();
        }

        private void backstageViewButtonItem4_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            this.Close();
        }

        private void backstageViewTabItem1_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ProposNous o = new ProposNous();
            o.ShowDialog();
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fonction f = new Fonction();
            f.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TableHistory th = new TableHistory();
            th.ShowDialog();
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListeTribunal l = new ListeTribunal();
            l.Show();
        }

        private void barStaticItem62_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cause_archivé ca = new cause_archivé();
            ca.ShowDialog();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            orderArchivé o = new orderArchivé();
            o.ShowDialog();
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            plainteArchivé p = new plainteArchivé();
            p.ShowDialog();
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tablirat a = new Tablirat();
            a.Show();
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tanfidate t = new Tanfidate();
            t.Show();
        }

        private void accordionControlElement1_Click_1(object sender, EventArgs e)
        {

        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Coercition_Physique c = new Coercition_Physique();
            c.Show();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            جلسات_الشكاية g = new جلسات_الشكاية();
            g.Show();
        }

    }
}

