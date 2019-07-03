using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using AvocaBin.Models;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvocaBin.Operation
{
    class Coercition_PhysiqueOP
    {
        SqlConnection cn = connection.getConnection(); //Instanciation de la connection a partire d'une classe connection.

        public void addCoercitionPhysique(CoercitionPhysique cp)
        {
            SqlConnection cn = connection.getConnection(); //Instanciation de la connection a partire d'une classe connection.

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into coercition_physique (n_dossier,client,type_cause,tribune,ville,ndossier_implement,intime,commissaire_juridique,date_application)values(@n,@c,@tc,@t,@v,@ni,@i,@cj,@da)", cn);
                SqlParameter p1 = new SqlParameter("@n", cp.N_dossier);
                SqlParameter p2 = new SqlParameter("@c", cp.Client);
                SqlParameter p3 = new SqlParameter("@tc", cp.Type_cause);
                SqlParameter p4 = new SqlParameter("@t", cp.Tribune);
                SqlParameter p5 = new SqlParameter("@v", cp.Ville);
                SqlParameter p6 = new SqlParameter("@ni", cp.Ndossier_implement);
                SqlParameter p7 = new SqlParameter("@i", cp.Intime);
                SqlParameter p8 = new SqlParameter("@cj", cp.Commissaire_juridique);
                SqlParameter p9 = new SqlParameter("@da", cp.Date_application);
               
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                MessageBox.Show("تمت الإضافة بنجاح");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
                //Console.WriteLine(e.Message);
            }

        }
        //Methode deleteCoericitionPhysique: pour supprimer des COERCITION PHYSIQUE.
        public void deleteCoercitionPhysique(int idcp)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand command = new SqlCommand("DELETE FROM coercition_physique WHERE n_coercition_physique = '" + idcp + "'", cn);
                command.ExecuteNonQuery();
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
               
        //Methode updateCoercitionPhysique : pour la modification des COERCITIION PHYSIQUE.
        public void updateCoercitionPhysique(CoercitionPhysique cp)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update coercition_physique set n_dossier=@nd,client=@c,type_cause=@tc,tribune=@t,ville=@v,ndossier_implement=@ni,intime=@i,commissaire_juridique=@cj,date_application=@da where n_coercition_physique=@ncp", cn);
                SqlParameter p0 = new SqlParameter("@nd", cp.N_dossier);
                SqlParameter p1 = new SqlParameter("@ncp", cp.N_coercition_physique);
                SqlParameter p3 = new SqlParameter("@c", cp.Client);
                SqlParameter p4 = new SqlParameter("@tc", cp.Type_cause);
                SqlParameter p5 = new SqlParameter("@t", cp.Tribune);
                SqlParameter p6 = new SqlParameter("@v", cp.Ville);
                SqlParameter p7 = new SqlParameter("@ni", cp.Ndossier_implement);
                SqlParameter p8 = new SqlParameter("@i", cp.Intime);
                SqlParameter p9 = new SqlParameter("@cj",cp.Commissaire_juridique);
                SqlParameter p10 = new SqlParameter("@da", cp.Date_application);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                MessageBox.Show("تم التعديل بنجاح ");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
                //Console.WriteLine(e.Message);
            }
        }
        //getAllPlante return tous les Plaintes non archivé
        public List<CoercitionPhysique> getAllCoercitionPhysique()
                {
                    List<CoercitionPhysique> cPhysique = new List<CoercitionPhysique>();
                    if (cn.State == ConnectionState.Closed) { cn.Open(); }
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM coercition_physique", cn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
              while (reader.Read())
              {
                  CoercitionPhysique p = new CoercitionPhysique();
                  p.N_coercition_physique = (int)reader["n_coercition_physique"];
                  p.N_dossier = (String)reader["n_dossier"];
                  p.Client = (String)reader["client"];
                  p.Type_cause = (String)reader["type_cause"];
                  p.Tribune = (String)reader["tribune"];
                  p.Ville = (String)reader["ville"];
                  p.Ndossier_implement = (String)reader["ndossier_implement"];
                  p.Intime = (String)reader["intime"];
                  p.Commissaire_juridique = (String)reader["commissaire_juridique"];
                  cPhysique.Add(p);
              }
              cn.Close();
              return cPhysique ;
                }
        //chercher un plaignant par id ou CIN
        public List<CoercitionPhysique> getSearchCphysique(String mc)
        {
            List<CoercitionPhysique> cPhysique = new List<CoercitionPhysique>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM coercition_physique where n_coercition_physique like @x or n_dossier like @z", cn);
            sqlCommand.Parameters.Add("@x", "%" + mc + "%");
            sqlCommand.Parameters.Add("@z", "%" + mc + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                CoercitionPhysique p = new CoercitionPhysique();
                p.N_coercition_physique = (int)reader["n_coercition_physique"];
                p.N_dossier = (String)reader["n_dossier"];
                p.Client = (String)reader["client"];
                p.Type_cause = (String)reader["type_cause"];
                p.Tribune = (String)reader["tribune"];
                p.Ville = (String)reader["ville"];
                p.Ndossier_implement = (String)reader["ndossier_implement"];
                p.Intime = (String)reader["intime"];
                p.Commissaire_juridique = (String)reader["commissaire_juridique"];
                p.Date_application = (DateTime)reader["date_application"];
                cPhysique.Add(p);
            }
            cn.Close();
            return cPhysique;
        }
    }
}
