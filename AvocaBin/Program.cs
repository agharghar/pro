using System;
using DevExpress;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using AvocaBin.Controller;
using System.Data.SqlClient;
using System.Threading;
using System.Data;
using AvocaBin.Report;

namespace AvocaBin
{
    static class Program
    {
        public static void Splashs()
        {
            Application.Run(new Splash());
        }
         //<summary>
         //The main entry point for the application.
         //</summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            Thread t = new Thread(new ThreadStart(Splashs));
            t.Start();
            Thread.Sleep(4500);
            t.Abort();
            bool test = true;
            //Application.Run(new ConfigurationServer());

            try
            {
                if (Properties.Settings.Default.Mode == "SQL" && (Properties.Settings.Default.ID == "" || Properties.Settings.Default.PassWord == ""))
                {
                    test = false;
                }
                if (Properties.Settings.Default.Server.ToString() == "" || Properties.Settings.Default.DataBase.ToString() == "")
                {
                    test = false;
                }
                if (Properties.Settings.Default.Mode != "SQL" && (Properties.Settings.Default.Server.ToString() == "" || Properties.Settings.Default.DataBase.ToString() == ""))
                {
                    test = false;
                }

                if (test == false)
                {
                    Application.Run(new ConfigurationServer());
                }
                else
                {
                    SqlConnection cnx = connection.getConnection();
                    SqlCommand cmd = new SqlCommand();
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    cmd.Connection = cnx;
                    cmd.CommandText = "select count(IdUtilisateur) from Utilisateur";
                    int q = 1;
                    int d;
                    d = (int)cmd.ExecuteScalar();
                    cnx.Close();
                    if (d >= q)
                    {
                        Application.Run(new Login());
                    }
                    else
                    {
                        Application.Run(new FormMain());
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
