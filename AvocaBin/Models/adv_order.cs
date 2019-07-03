using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//created by : Ahmed Ouberka
//date : 06/08/2017
//email : ahmedouberka@hotmail.com

namespace AvocaBin
{
    class adv_order
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public int id_adv_order { get; set; }
        public string type_adv_order { get; set; }
        public string cin { get; set; }
        public string nom { get; set; }
        public string representant_legal { get; set; }
        public string registre_commerce { get; set; }
        public string adresse { get; set; }

        public int save()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "insert into adv_order Output Inserted.id_adv_order values(@type,@cin,@nom,@repres,@regist,@adr)";
            cmd.Parameters.Add("@type", type_adv_order);
            cmd.Parameters.Add("@cin", cin);
            cmd.Parameters.Add("@nom", nom);
            cmd.Parameters.Add("@repres", representant_legal);
            cmd.Parameters.Add("@regist", registre_commerce);
            cmd.Parameters.Add("@adr", adresse);
            int id = (int)cmd.ExecuteScalar();
            cn.Close();
            return id;
        }

        //find a record by it's id
        public static adv_order findById(int id)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from adv_order where id_adv_order = @id";
            cmd.Parameters.Add("@id", id);
            dr = cmd.ExecuteReader();
            dr.Read();
            adv_order advOrd = new adv_order();
            advOrd.id_adv_order = id;
            advOrd.type_adv_order = (string)dr["type_adv_order"];
            advOrd.cin = (string)dr["cin"];
            advOrd.nom = (string)dr["nom"];
            advOrd.representant_legal = (string)dr["representant_legal"];
            advOrd.registre_commerce = (string)dr["registre_commerce"];
            advOrd.adresse = (string)dr["adresse"];
            cn.Close();
            dr.Close();
            return advOrd;
        }

        //check all columns for a matching word
        public static List<adv_order> find(string word)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from adv_order where id_adv_order like @word or type_adv_order like @word or cin like @word or nom like @word or representant_legal like @word or registre_commerce like @word or adresse like @word";
            cmd.Parameters.Add("@word", word);
            dr = cmd.ExecuteReader();
            List<adv_order> listCl = new List<adv_order>();
            while (dr.Read())
            {
                adv_order cl = new adv_order();
                cl.id_adv_order = (int)dr["id_adv_order"];
                cl.type_adv_order = (string)dr["type_adv_order"];
                cl.cin = (string)dr["cin"];
                cl.nom = (string)dr["nom"];
                cl.representant_legal = (string)dr["representant_legal"];
                cl.registre_commerce = (string)dr["registre_commerce"];
                cl.adresse = (string)dr["adresse"];
                listCl.Add(cl);
            }
            dr.Close();
            cn.Close();
            return listCl;
        }

        //destroy this record
        public int delete()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete adv_order where id_adv_order = @word";
            cmd.Parameters.Add("@word", id_adv_order);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }

        //update this record
        public int update()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update adv_order set type_adv_order=@type ,cin=@cin ,nom=@nom ,representant_legal=@repres ,registre_commerce=@registre ,adresse=@adr where id_adv_order=@id";
            cmd.Parameters.Add("@id", id_adv_order);
            cmd.Parameters.Add("@type", type_adv_order);
            cmd.Parameters.Add("@cin", cin);
            cmd.Parameters.Add("@nom", nom);
            cmd.Parameters.Add("@repres", representant_legal);
            cmd.Parameters.Add("@registre", registre_commerce);
            cmd.Parameters.Add("@adr", adresse);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }
    }
}
