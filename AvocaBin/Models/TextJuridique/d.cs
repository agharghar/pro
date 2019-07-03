using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AvocaBin.Models;

namespace AvocaBin
{
    public static class d
    {
    //   public static SqlConnection cn =  connection.getConnection();
    //    public static SqlDataAdapter da;
    //    public  static SqlCommand cmd = new SqlCommand();
    //    public static DataSet ds = new DataSet();

    //    public static void OpenConnection()
    //    {
    //        if (cn.State == ConnectionState.Closed)
    //        {
    //            cn.Open();
    //        }
    //    }

    //    public static int AfficherUneSeulValeurEntier(string req)
    //    {
    //        try
    //        {
    //            OpenConnection();
    //            cmd = new SqlCommand(req, cn);
    //            // int h =Convert.ToInt32( cmd.ExecuteScalar());
    //            return int.Parse(cmd.ExecuteScalar().ToString());
    //            // return h;
    //        }
    //        catch (Exception)
    //        {
    //            return -1;
    //        }
    //    }
         
    //    public static string AfficherUneSeulValeur(string req)
    //    {
    //        try
    //        {
    //            OpenConnection();
    //            cmd = new SqlCommand(req);
    //            cmd.Connection = cn;
    //            return cmd.ExecuteScalar().ToString();
    //        }
    //        catch (Exception)
    //        {
    //            return "";
    //        }
    //        //return null;
    //    }

    //    public static void MiseAjour(string req)
    //    {
    //        OpenConnection();
    //        cmd = new SqlCommand(req, cn);
    //        cmd.ExecuteNonQuery();
    //    }
    //    public static void ChargerDataSet(string req, string table)
    //    {
    //        if (ds.Tables.Contains(table))
    //        {
    //            ds.Tables[table].Clear();
    //        }
    //        da = new SqlDataAdapter(req, cn);
    //        da.Fill(ds, table);
    //    }
    //    public static void ChargerCombobox(string req,string table,ComboBox cmb,string ValeurAfficher,string ValeurCache)
    //    {
    //        ChargerDataSet(req, table);
    //        cmb.DataSource = ds.Tables[table];
    //        cmb.ValueMember = ValeurCache;
    //        cmb.DisplayMember=ValeurAfficher;
    //    }
    //    public static void RemplirGridView(string req, string table,DataGridView gr)
    //    {
    //        ChargerDataSet(req, table);
    //        gr.DataSource = ds.Tables[table];

    //    }

    }
}
