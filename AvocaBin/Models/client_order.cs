using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin
{
    class client_order
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public int id_client_order { get; set; }
        public string type_client_order { get; set; }
        public string cin { get; set; }
        public string nom { get; set; }
        public string telephone { get; set; }
        public string representant_legal { get; set; }
        public string registre_commerce { get; set; }
        public string adresse { get; set; }

        //insert a new client to DB
        public int save()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "insert into client_order Output Inserted.id_client_order values(@type,@cin,@nom,@tel,@repres,@regist,@adr)";
            cmd.Parameters.Add("@type", type_client_order);
            cmd.Parameters.Add("@cin", cin);
            cmd.Parameters.Add("@nom", nom);
            cmd.Parameters.Add("@tel", cin);
            cmd.Parameters.Add("@repres", representant_legal);
            cmd.Parameters.Add("@regist", registre_commerce);
            cmd.Parameters.Add("@adr", adresse);
            int t = (int)cmd.ExecuteScalar();
            cn.Close();
            return t;
        }

        //find client order by id_client_order
        public static client_order findById(int id)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from client_order where id_client_order = @id";
            cmd.Parameters.Add("@id", id);
            dr = cmd.ExecuteReader();
            client_order cl = new client_order();
            dr.Read();
            cl.id_client_order = id;
            cl.type_client_order = (string)dr["type_client_order"];
            cl.cin = (string)dr["cin"];
            cl.nom = (string)dr["nom"];
            cl.telephone = (string)dr["telephone"];
            cl.representant_legal = (string)dr["representant_legal"];
            cl.registre_commerce = (string)dr["registre_commerce"];
            cl.adresse = (string)dr["adresse"];
            cn.Close();
            dr.Close();
            return cl;
        }

        //check all columns for matching word
        public static List<client_order> find(string word)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from client_order where id_client_order like @word or type_client_order like @word or cin like @word or nom like @word or telephone like @word or representant_legal like @word or registre_commerce like @word or adresse like @word";
            cmd.Parameters.Add("@word", word);
            dr = cmd.ExecuteReader();
            List<client_order> listCl = new List<client_order>();
            while (dr.Read())
            {
                client_order cl = new client_order();
                cl.id_client_order = (int)dr["id_client_order"];
                cl.type_client_order = (string)dr["type_client_order"];
                cl.cin = (string)dr["cin"];
                cl.nom = (string)dr["nom"];
                cl.telephone = (string)dr["telephone"];
                cl.representant_legal = (string)dr["representant_legal"];
                cl.registre_commerce = (string)dr["registre_commerce"];
                cl.adresse = (string)dr["adresse"];
                listCl.Add(cl);
            }
            dr.Close();
            cn.Close();
            return listCl;
        }


        //update the client_order record
        public int update()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update client_order set type_client_order=@type ,cin=@cin ,nom=@nom ,telephone=@tel ,representant_legal=@repres ,registre_commerce=@registre ,adresse=@adr where id_client_order=@id";
            cmd.Parameters.Add("@id", id_client_order);
            cmd.Parameters.Add("@type", type_client_order);
            cmd.Parameters.Add("@cin", cin);
            cmd.Parameters.Add("@nom", nom);
            cmd.Parameters.Add("@tel", telephone);
            cmd.Parameters.Add("@repres", representant_legal);
            cmd.Parameters.Add("@registre", registre_commerce);
            cmd.Parameters.Add("@adr", adresse);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }

        //delete this record
        public int delete()
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete client_order where id_client_order = @id";
            cmd.Parameters.Add("@id", id_client_order);
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }
    }
}
