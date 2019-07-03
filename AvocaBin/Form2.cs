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
using System.Configuration;
using System.Data.SqlClient;


namespace AvocaBin
{

    public partial class Form2 : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();
        SqlDataAdapter da2 = new SqlDataAdapter();
        SqlDataAdapter da3 = new SqlDataAdapter();
        SqlDataAdapter da4 = new SqlDataAdapter();
        PrintPlaintDataSet ds = new PrintPlaintDataSet();
        PrintDecisionDataSet ds1 = new PrintDecisionDataSet();
        SqlConnection cn = connection.getConnection();
        string strServer;
        string strDatabase;
        string strUserID;
        string strPwd;
        String id_plainte;
        public Form2(String id_plainte)
        {
            this.id_plainte = id_plainte;
            InitializeComponent();
        }
        public Form2()
        {
            
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd = new SqlCommand("select id_plainte,date_creation,signe_plainte,type_plainte from plainte where id_plainte like '" + id_plainte + "'", cn);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "plainte");

                cmd1 = new SqlCommand("select top(1) * from avocat", cn);
                da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds, "avocat");


                cmd2 = new SqlCommand("select plaignant.* from plaignant,plainte where plainte.id_plainte like '" + id_plainte + "' and plainte.id_plaignant=plaignant.id_plaignant", cn);
                da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds, "plaignant");

                cmd3 = new SqlCommand("select par_plaignant.* from par_plaignant,plainte,plainte_par_plaignant where plainte.id_plainte like '" + id_plainte + "' and plainte_par_plaignant.id_plainte=plainte.id_plainte and plainte_par_plaignant.id_par_plaignant=par_plaignant.id_par_plaignant", cn);
                da3 = new SqlDataAdapter(cmd3);
                da3.Fill(ds, "par_plaignant");

                cmd4 = new SqlCommand("select * from decision_plainte where id_plainte like '" + id_plainte + "'", cn);
                da4 = new SqlDataAdapter(cmd4);
                da4.Fill(ds1, "decision_plainte");

                SubReportDecisionCrystalReport s = new SubReportDecisionCrystalReport();
                s.SetDataSource(ds1);

                PrintOnePlainteCrystalReport i = new PrintOnePlainteCrystalReport();

                i.SetDataSource(ds);
                i.Subreports["SubReportDecisionCrystalReport.rpt"].SetDataSource(ds1);
                i.OpenSubreport("SubReportDecisionCrystalReport.rpt");
                i.Refresh();

                crystalReportViewer1.ReportSource = i;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

      

       
        }
}


