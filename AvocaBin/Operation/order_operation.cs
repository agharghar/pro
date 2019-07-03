using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AvocaBin.Operation;
using AvocaBin.Models;
using System.Data;

namespace AvocaBin.Operation
{
    class order_operation
    {
        SqlConnection cn = connection.getConnection();
         public List<depot_order> detDepotOrder()
        {
            List<depot_order> dc = new List<depot_order>();

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("select do.id_depot,do.id_order,co.nom,ao.nom as[nom_adv],do.num_check,do.montant from depot_order do,client_order co ,adv_order ao where co.id_client_order=do.id_client_order and ao.id_adv_order=do.id_adv_order", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                depot_order c = new depot_order();
                c.Id_depot = (int)reader["id_depot"];
                c.Id_order = (string)reader["id_order"];
                c.Nom = (string)reader["nom"];
                c.Nom_adv = (string)reader["nom_adv"];
                c.Num_check = (string)reader["num_check"];
                c.Montant = float.Parse(reader["montant"].ToString());
                dc.Add(c);
            }
            cn.Close();
            return dc;
        }

         //
         //
         //search depot plainte
         //
         //
         //

         public List<depot_order> seardepot_order(string id)
         {
             List<depot_order> cc = new List<depot_order>();
             if (cn.State == ConnectionState.Closed) { cn.Open(); }
             SqlCommand sqlCommand = new SqlCommand("select do.id_depot,do.id_order,co.nom,ao.nom as[nom_adv],do.num_check,do.montant from depot_order do,client_order co ,adv_order ao where do.id_order like'"+id+"%' and co.id_client_order=do.id_client_order and ao.id_adv_order=do.id_adv_order", cn);
             SqlDataReader reader = sqlCommand.ExecuteReader();
             while (reader.Read())
             {
                 depot_order c = new depot_order();
                 c.Id_depot = (int)reader["id_depot"];
                 c.Id_order = (string)reader["id_order"];
                 c.Nom = (string)reader["nom"];
                 c.Nom_adv = (string)reader["nom_adv"];
                 c.Num_check = (string)reader["num_check"];
                 c.Montant = float.Parse(reader["montant"].ToString());

                 cc.Add(c);
             }
             cn.Close();
             return cc;
         }
    }
}
