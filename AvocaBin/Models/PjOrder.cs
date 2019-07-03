using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin
{
    class PjOrder
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public int id_pj { get; set; }
        public byte[] photo { get; set; }
        public string titre { get; set; }
        public string date_enregistrement { get; set; }
        public string id_order { get; set; }

        public int save()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "insert into PJ_order Output Inserted.id_pj values(@photo,@titre,@date,@idOrd)";
            cmd.Parameters.Add("@photo", photo);
            cmd.Parameters.Add("@titre", titre);
            cmd.Parameters.Add("@date", date_enregistrement);
            cmd.Parameters.Add("@idOrd", id_order);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }

        //find a file by it's id
        public PjOrder find(int id)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from where id_pj = @id";
            cmd.Parameters.Add("@id", id);
            dr = cmd.ExecuteReader();
            PjOrder pj = new PjOrder();
            pj.id_pj = (int)dr["id_pj"];
            pj.photo = (byte[])dr["photo"];
            pj.titre = (string)dr["titre"];
            pj.date_enregistrement = (string)dr["date_enregistrement"];
            pj.id_order = (string)dr["id_order"];
            dr.Close();
            return pj;
        }

        //find an order files by it's ID
        public static List<PjOrder> findOrderPj(string idOrder)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            List<PjOrder> listPj = new List<PjOrder>();

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from PJ_order where id_order like @order";
            cmd.Parameters.Add( new SqlParameter("@order", idOrder));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PjOrder pj = new PjOrder();
                pj.id_pj = (int)dr["id_pj"];
                pj.photo = (byte[])dr["photo"];
                pj.titre = (string)dr["titre"];
                DateTime d = new DateTime();
                d = (DateTime)dr["date_enregistrement"];
                pj.date_enregistrement = d.ToShortDateString();
                pj.id_order = (string)dr["id_order"];
                listPj.Add(pj);
            }
            dr.Close();
            cn.Close();
            return listPj;
        }
    }
}
