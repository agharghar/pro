using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvocaBin
{
    class order
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();

        public string id_order { get; set; }
        public string signe_order { get; set; }
        public DateTime  date_order { get; set; }
        public string commissaire_judicaire { get; set; }
        public string id_ville { get; set; }
        public string type_tribuna { get; set; }
        public int id_client_order { get; set; }
        public int id_adversaire_order { get; set; }
        public string decision { get; set; }
        public string type { get; set; }

        public int save()
        {
            int t=0;
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd.Connection = cn;
                cmd.CommandText = "insert into orderr values(@id,@signe,@date,@comm,@idVille,@tri,@idClient,@idAdv,@decision,@type,NULL,'non archivé')";
                cmd.Parameters.Add("@id", id_order);
                cmd.Parameters.Add("@signe", signe_order);
                cmd.Parameters.Add("@date", date_order);
                cmd.Parameters.Add("@comm", commissaire_judicaire);
                cmd.Parameters.Add("@idVille", id_ville);
                cmd.Parameters.Add("@tri", type_tribuna);
                cmd.Parameters.Add("@idClient", id_client_order);
                cmd.Parameters.Add("@idAdv", id_adversaire_order);
                cmd.Parameters.Add("@decision", decision);
                cmd.Parameters.Add("@type", type);
                t = (int)cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return t;
        }
        
        //delete this order record
        public static int delete(string id)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete orderr where id_order = @id";
            cmd.Parameters.Add("@id", id);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            cmd.Parameters.Clear();
            return t;
        }

        //update this order record
        public int update()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update orderr set signe_order=@signe ,commissaire_judiciaire=@comm ,ville=@ville ,tribunal=@tribunal ,id_client_order=@idcli ,id_adversaire_order=@idad ,decision=@decision ,type=@type where id_order=@id";
            cmd.Parameters.Add("@signe", signe_order);
            cmd.Parameters.Add("@comm", commissaire_judicaire);
            cmd.Parameters.Add("@ville", id_ville);
            cmd.Parameters.Add("@tribunal", type_tribuna);
            cmd.Parameters.Add("@idcli", id_client_order);
            cmd.Parameters.Add("@idad", id_adversaire_order);
            cmd.Parameters.Add("@decision", decision);
            cmd.Parameters.Add("@type", type);
            cmd.Parameters.Add("@id", id_order);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            cmd.Parameters.Clear();
            return t;
        }
        public void deletePieceJointe_Order(int id_pj)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE FROM PJ_order WHERE id_pj=" + id_pj, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحدف بنجاح ");
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
    }

}
