using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvocaBin.Models.Plaintes;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvocaBin.Operation
{
    class PlaintesOperations
    {
        SqlConnection cn = connection.getConnection(); //Instanciation de la connection a partire d'une classe connection.

        //addPlainte est une methode qui nous donne le droit d'ajouter des nouveaux planites
        public void addPlainte(Plainte p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into plainte(id_plainte,date_creation,signe_plainte,id_plaignant,ville,tribunal,type_plainte,etat,date_depot_plainte)values(@a,@date,@e,@r,@t,@y,@typePlainte,'non archivé',@dd)", cn);
                SqlParameter p1 = new SqlParameter("@a", p.IdPlainte);
                SqlParameter p8= new SqlParameter("@date", p.DateCreation);
                SqlParameter p9 = new SqlParameter("@dd", p.DateDepotPlainte);
                SqlParameter p3 = new SqlParameter("@e", p.SignePlainte);
                SqlParameter p4 = new SqlParameter("@r", p.IdPlaignant);
                SqlParameter p5 = new SqlParameter("@t", p.Ville);
                SqlParameter p6 = new SqlParameter("@y", p.TypeTribunal);
                SqlParameter p7 = new SqlParameter("@typePlainte", p.TypePlaint);
               // SqlParameter p9 = new SqlParameter("@etat", p.Etat);
                cmd.Parameters.Add(p1);
               
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

        //Methode deletePlainte : pour supprimer des plaintes.
        public void deletePlainte(String idplante)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                   SqlCommand command = new SqlCommand("DELETE FROM plainte WHERE id_plainte = '" + idplante + "'", cn);
                   command.ExecuteNonQuery();
                   cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        //Methode deletePlainte : pour supprimer des plaintes.
        public void updatePlainte(Plainte p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update plainte set date_creation=@d,signe_plainte=@e,id_plaignant=@r,ville=@t,tribunal=@y,date_depot_plainte=@dd where id_plainte=@a", cn);
                SqlParameter p0 = new SqlParameter("@d", p.DateCreation);
                SqlParameter p1 = new SqlParameter("@a", p.IdPlainte);
                SqlParameter p3 = new SqlParameter("@e", p.SignePlainte);
                SqlParameter p4 = new SqlParameter("@r", p.IdPlaignant);
                SqlParameter p5 = new SqlParameter("@t", p.Ville);
                SqlParameter p6 = new SqlParameter("@y", p.TypeTribunal);
                SqlParameter p7 = new SqlParameter("@dd", p.DateDepotPlainte);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
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
        public List<Plainte> getAllPlante()
        {
            List<Plainte> plaintes = new List<Plainte>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand= new SqlCommand("SELECT * FROM plainte where etat='non archivé'", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
      while (reader.Read())
      {
          Plainte p = new Plainte();
          p.IdPlainte = (String)reader["id_plainte"];
          p.DateCreation = (DateTime)reader["date_creation"];
          p.SignePlainte = (String)reader["signe_plainte"];
          p.IdPlaignant = (int)reader["id_plaignant"];
          p.Ville = (String)reader["ville"];
          p.TypeTribunal = (String)reader["tribunal"];
          p.TypePlaint=(String)reader["type_plainte"];
          p.DateDepotPlainte = (DateTime)reader["date_depot_plainte"];
          plaintes.Add(p);
      }
      cn.Close();
      return plaintes ;
        }

        //getAllPlante return tous les Plaintes archiveé
        public List<Plainte> getAllPlanteArchivé()
        {
            List<Plainte> plaintes = new List<Plainte>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plainte where etat='archivé'", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Plainte p = new Plainte();
                p.Num_archive = (string)reader["num_archive"];
                p.IdPlainte = (String)reader["id_plainte"];
                p.DateCreation = (DateTime)reader["date_creation"];
                p.SignePlainte = (String)reader["signe_plainte"];
                p.IdPlaignant = (int)reader["id_plaignant"];
                p.Ville = (String)reader["ville"];
                p.TypeTribunal = (String)reader["tribunal"];
                p.TypePlaint = (String)reader["type_plainte"];
                p.DateDepotPlainte = (DateTime)reader["date_depot_plainte"];
                plaintes.Add(p);
            }
            cn.Close();
            return plaintes;
        }

        //Rechercher une plante par id_plante
        public List<Plainte> getPlanteArchiveById(String id_plante)
        {
            List<Plainte> plaintes = new List<Plainte>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plainte where (id_plainte like @x or num_archive like @x) and etat='archivé'", cn);
            sqlCommand.Parameters.Add("@x", "%" + id_plante + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Plainte p = new Plainte();
                p.Num_archive = (string)reader["num_archive"];
                p.IdPlainte = (String)reader["id_plainte"];
                p.DateCreation = (DateTime)reader["date_creation"];
                p.SignePlainte = (String)reader["signe_plainte"];
                p.IdPlaignant = (int)reader["id_plaignant"];
                p.Ville = (String)reader["ville"];
                p.TypeTribunal = (String)reader["tribunal"];
                p.TypePlaint = (String)reader["type_plainte"];
                p.DateDepotPlainte = (DateTime)reader["date_depot_plainte"];
                plaintes.Add(p);
            }
            cn.Close();
            return plaintes;
        }

        //Rechercher une plante par id_plante
        public List<Plainte> getPlanteById(String id_plante)
        {
            List<Plainte> plaintes = new List<Plainte>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plainte where id_plainte like @x and etat='non archivé'", cn);
            sqlCommand.Parameters.Add("@x", "%" + id_plante + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Plainte p = new Plainte();
                //p.Num_archive = (string)reader["num_archive"];
                p.IdPlainte = (String)reader["id_plainte"];
                p.DateCreation = (DateTime)reader["date_creation"];
                p.SignePlainte = (String)reader["signe_plainte"];
                p.IdPlaignant = (int)reader["id_plaignant"];
                p.Ville = (String)reader["ville"];
                p.TypeTribunal = (String)reader["tribunal"];
                p.TypePlaint = (String)reader["type_plainte"];
                p.DateDepotPlainte = (DateTime)reader["date_depot_plainte"];

                plaintes.Add(p);
            }
            cn.Close();
            return plaintes;
        }



        /*
         * 
         * partie de par_plaignats
         * 
        */
        public void addParPlaignant(Par_plaignant p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into par_plaignant(type_par_plaignant,cin,nom,representant_legal,registre_commerce,adresse)values(@b,@z,@e,@r,@t,@y)", cn);
                
                SqlParameter p1 = new SqlParameter("@b", p.TypeParPlaignant);
                SqlParameter p2 = new SqlParameter("@z", p.Cin);
                SqlParameter p3 = new SqlParameter("@e", p.Nom);
                SqlParameter p4 = new SqlParameter("@r", p.RepresentantLegal);
                SqlParameter p5 = new SqlParameter("@t", p.RegistreDeCommerce1);
                SqlParameter p6 = new SqlParameter("@y", p.Adresse);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
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

        //Methode deletePlainte : pour supprimer des plaintes.
        public void deleteParPlaignant(String idparPlaignant)
        {
            try
            {
                int id = int.Parse(idparPlaignant);
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand command = new SqlCommand("DELETE FROM par_plaignant WHERE id_par_plaignant ="+id, cn);
                command.ExecuteNonQuery();
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        //Methode update : pour supprimer des plaintes.
        public void updateParPlaignant(Par_plaignant p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update par_plaignant set type_par_plaignant=@d,cin=@z,nom=@e,representant_legal=@r,registre_commerce=@t,adresse=@y where id_par_plaignant=@a", cn);
                SqlParameter p0 = new SqlParameter("@a", p.IdParPlaignant);
                SqlParameter p1 = new SqlParameter("@d", p.TypeParPlaignant);
                SqlParameter p2 = new SqlParameter("@z", p.Cin);
                SqlParameter p3 = new SqlParameter("@e", p.Nom);
                SqlParameter p4 = new SqlParameter("@r", p.RepresentantLegal);
                SqlParameter p5 = new SqlParameter("@t", p.RegistreDeCommerce1);
                SqlParameter p6 = new SqlParameter("@y", p.Adresse);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
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

        //getAllParpLaignant return tous les plaignant
        public List<Par_plaignant> getAllParPlaignant()
        {
            List<Par_plaignant> parplaignants = new List<Par_plaignant>();
            try
            {

                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM par_plaignant", cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Par_plaignant p = new Par_plaignant();
                    p.IdParPlaignant = (int)reader["id_par_plaignant"];
                    p.TypeParPlaignant = (String)reader["type_par_plaignant"];
                    p.Cin = (String)reader["cin"];
                    p.Nom = (String)reader["nom"];
                    p.RepresentantLegal = (String)reader["representant_legal"];
                    p.RegistreDeCommerce1 = (String)reader["registre_commerce"];
                    p.Adresse = (String)reader["adresse"];
                    parplaignants.Add(p);
                }
                cn.Close();
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return parplaignants;
            
            
        }


        //chercher un parplaignant par id_par_plaignant ou cin
        public List<Par_plaignant> getParPlaignantByIdAndCIN(String mc)
        {
            List<Par_plaignant> parplaignants = new List<Par_plaignant>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM par_plaignant where id_par_plaignant like @x or cin like @z or nom like @k", cn);
            sqlCommand.Parameters.Add("@x", "%" + mc + "%");
            sqlCommand.Parameters.Add("@z", "%" + mc + "%");
            sqlCommand.Parameters.Add("@k", "%" + mc + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Par_plaignant p = new Par_plaignant();
                p.IdParPlaignant = (int)reader["id_par_plaignant"];
                p.TypeParPlaignant = (String)reader["type_par_plaignant"];
                p.Cin = (String)reader["cin"];
                p.Nom = (String)reader["nom"];
                p.RepresentantLegal = (String)reader["representant_legal"];
                p.RegistreDeCommerce1 = (String)reader["registre_commerce"];
                p.Adresse = (String)reader["adresse"];
                parplaignants.Add(p);
            }
            cn.Close();
            return parplaignants;
        }



        /*
       * 
       * partie de plaignats
       * 
      */
        public void addPlaignant(Plaignant p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into plaignant(type_plaignant,cin,nom,telephone,representant_legal,registre_commerce,adresse)values(@b,@z,@e,@k,@r,@t,@y)", cn);
               
                SqlParameter p1 = new SqlParameter("@b", p.TypePlaignant);
                SqlParameter p7 = new SqlParameter("@k", p.Telephone);
                SqlParameter p2 = new SqlParameter("@z", p.Cin);
                SqlParameter p3 = new SqlParameter("@e", p.Nom);
                SqlParameter p4 = new SqlParameter("@r", p.RepresentantLegal);
                SqlParameter p5 = new SqlParameter("@t", p.RegistreDeCommerce1);
                SqlParameter p6 = new SqlParameter("@y", p.Adresse);
               
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
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

        //Methode deletePlaignant : pour supprimer des plaignants.
        public void deletePlaignant(String idPlaignant)
        {
            int id = int.Parse(idPlaignant);
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand command = new SqlCommand("DELETE FROM plaignant WHERE id_plaignant = " + id , cn);
                command.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("تم الحذف بنجاح");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        //Methode updatePlaignant : pour modifier des plaignants.
        public void updatePlaignant(Plaignant p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update plaignant set type_plaignant=@d,cin=@z,nom=@e,telephone=@k,representant_legal=@r,registre_commerce=@t,adresse=@y where id_plaignant=@a", cn);
                SqlParameter p0 = new SqlParameter("@a", p.IdPlaignant);
                SqlParameter p1 = new SqlParameter("@d", p.TypePlaignant);
                SqlParameter p7 = new SqlParameter("@k", p.Telephone);
                SqlParameter p2 = new SqlParameter("@z", p.Cin);
                SqlParameter p3 = new SqlParameter("@e", p.Nom);
                SqlParameter p4 = new SqlParameter("@r", p.RepresentantLegal);
                SqlParameter p5 = new SqlParameter("@t", p.RegistreDeCommerce1);
                SqlParameter p6 = new SqlParameter("@y", p.Adresse);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
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

        //getAllPlaignant return tous les palaignants
        public List<Plaignant> getAllPlaignant()
        {
            List<Plaignant> plaignants = new List<Plaignant>();
            
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plaignant", cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Plaignant p = new Plaignant();
                    p.IdPlaignant = (int)reader["id_plaignant"];
                    p.TypePlaignant = (String)reader["type_plaignant"];
                    p.Cin = (String)reader["cin"];
                    p.Nom = (String)reader["nom"];
                    p.RepresentantLegal = (String)reader["representant_legal"];
                    p.RegistreDeCommerce1 = (String)reader["registre_commerce"];
                    p.Adresse = (String)reader["adresse"];
                    p.Telephone = (String)reader["telephone"];
                    plaignants.Add(p);
                }
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
          
            return plaignants;
        }


        //chercher un plaignant par id ou CIN
        public List<Plaignant> getPlaignantByCinAndId(String mc)
        {
            List<Plaignant> plaignants = new List<Plaignant>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plaignant where id_plaignant like @x or cin like @z or nom like @k", cn);
            sqlCommand.Parameters.Add("@x", "%" + mc + "%");
            sqlCommand.Parameters.Add("@z", "%" + mc + "%");
            sqlCommand.Parameters.Add("@k", "%" + mc + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Plaignant p = new Plaignant();
                p.IdPlaignant = (int)reader["id_plaignant"];
                p.TypePlaignant = (String)reader["type_plaignant"];
                p.Cin = (String)reader["cin"];
                p.Nom = (String)reader["nom"];
                p.RepresentantLegal = (String)reader["representant_legal"];
                p.RegistreDeCommerce1 = (String)reader["registre_commerce"];
                p.Adresse = (String)reader["adresse"];
                p.Telephone = (String)reader["telephone"];
                plaignants.Add(p);
            }
            cn.Close();
            return plaignants;
        }

        //plainteParPlaignant
        public void addPlainteParPlaignant(PlainteParPlaignant ppp)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into plainte_par_plaignant(id_plainte,id_par_plaignant)values(@a,@b)", cn);
                SqlParameter p1 = new SqlParameter("@a", ppp.IdPlainte);
                SqlParameter p2 = new SqlParameter("@b", ppp.IdParPlaignant);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
               // MessageBox.Show("تمت الإضافة بنجاح");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
                //Console.WriteLine(e.Message);
            }

        }
        public  List<PlainteParPlaignant> getPlainteParPlaintes(String idplainte){
            List<PlainteParPlaignant> parplaignants = new List<PlainteParPlaignant>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM plainte_par_plaignant where id_plainte like @x", cn);
            sqlCommand.Parameters.Add("@x", "%" + idplainte + "%");

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PlainteParPlaignant ppp = new PlainteParPlaignant();
                ppp.IdParPlaignant = (int)reader["id_par_plaignant"];
                ppp.IdPlainte=(String)reader["id_plainte"];
                parplaignants.Add(ppp);
                
            }
            cn.Close();
            return parplaignants;
        }

        public void deleteplainteParpLainte(String idPlaignant)
        {
          
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand command = new SqlCommand("DELETE FROM plainte_par_plaignant WHERE id_plainte = '" + idPlaignant+"'", cn);
                command.ExecuteNonQuery();
               
               // MessageBox.Show("تم الحذف بنجاح");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
              cn.Close();

        }
        
        

          /*
           * 
         * PjPlainte
         * 
           * **/

        public void addPjPalainte(PjPlainte pp)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into PJ_plainte values(@photo,@titre,@date,@idplainte)", cn);
                SqlParameter p1 = new SqlParameter("@photo", pp.Photo);
                SqlParameter p2 = new SqlParameter("@titre",pp.Titre);
                SqlParameter p3 = new SqlParameter("@date", pp.Date_enregistrement);
                SqlParameter p4 = new SqlParameter("@idplainte", pp.Id_plainte);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                // MessageBox.Show("تمت الإضافة بنجاح");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
                //Console.WriteLine(e.Message);
            }
        }

        public void deletePJplainte(int idpj)
        {

            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand command = new SqlCommand("DELETE FROM PJ_plainte WHERE id_pj ="+idpj, cn);
                command.ExecuteNonQuery();

                 MessageBox.Show("تم الحذف بنجاح");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            cn.Close();

        }

        public List<PjPlainte> getPJPlainte(String idplainte)
        {
            List<PjPlainte> pjplaintes = new List<PjPlainte>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PJ_plainte where id_plainte like @x", cn);
            sqlCommand.Parameters.Add("@x", "%" + idplainte + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PjPlainte pj = new PjPlainte();
                pj.Id_pj = (int)reader["id_pj"];
                pj.Id_plainte = (String)reader["id_plainte"];
                pj.Titre = (String)reader["titre"];
                pj.Photo = (byte[])reader["photo"];
                // pj.Date_enregistrement=(String) reader["date_enregistrement"];
                pjplaintes.Add(pj);
            }
            cn.Close();
            return pjplaintes;
        }

            /*
             * 
             * Decision
             * 
             * 
             * */

            public void addDecisionPlainte(Decision d)
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert decision_plainte values(@b,@z)", cn);

                SqlParameter p1 = new SqlParameter("@b", d.Decision1);
                SqlParameter p2 = new SqlParameter("@z", d.Id_plainte);
             
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
              
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
            public List<Decision> getDecisionbyPlainte(String idplainte)
            {
                List<Decision> decisions = new List<Decision>();
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM decision_plainte where id_plainte like @x", cn);
                sqlCommand.Parameters.Add("@x", "%" + idplainte + "%");
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Decision d = new Decision();
                   d.Decision1 = (String)reader["decision"];
                    d.Id_plainte = (String)reader["id_plainte"];
                    
                    // pj.Date_enregistrement=(String) reader["date_enregistrement"];
                    decisions.Add(d);
                }
                cn.Close();
                return decisions ;
            }

        //
        //
        //get all depot_plainte
        //
            public List<depot_plaint> get_depot_plainte()
            {
                List<depot_plaint> depot_plaint = new List<depot_plaint>();

                try
                {
                    if (cn.State == ConnectionState.Closed) { cn.Open(); }
                    SqlCommand sqlCommand = new SqlCommand("select dp.id_depot,dp.id_plainte,p.nom,pp.nom as [nom_adv],dp.num_check,dp.montant from depot_plgn dp,plaignant p ,par_plaignant pp where p.id_plaignant=dp.id_plaignant and pp.id_par_plaignant=dp.id_par_plaignant", cn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        depot_plaint p = new depot_plaint();
                        p.Id_depot= (int)reader["id_depot"];
                        p.Id_plainte = (String)reader["id_plainte"];

                        p.Nom = (String)reader["nom"];
                        p.Nom_adv = (String)reader["nom_adv"];
                        p.Num_check = (string)reader["num_check"];
                        p.Montant = float.Parse(reader["montant"].ToString());

                        depot_plaint.Add(p);
                    }
                    cn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                return depot_plaint;
            }
            //
            //
            //search depot plainte
            //
            //
            //
            
            public List<depot_plaint> seardepot_plainte(string id)
            {
                List<depot_plaint> cc = new List<depot_plaint>();
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand sqlCommand = new SqlCommand("select dc.id_depot,dc.id_plainte,cc.nom,ad.nom as[nom_adv],dc.num_check,dc.montant from depot_plgn dc,plaignant cc,par_plaignant ad where dc.id_plainte like '"+id+"%' and dc.id_par_plaignant=ad.id_par_plaignant and dc.id_plaignant=cc.id_plaignant", cn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    depot_plaint c = new depot_plaint();
                    c.Id_depot = (int)reader["id_depot"];
                    c.Id_plainte = (string)reader["id_plainte"];
                    c.Nom = (string)reader["nom"];
                    c.Nom_adv = (string)reader["nom_adv"];
                    c.Num_check = (string)reader["num_check"];
                    c.Montant = float.Parse(reader["montant"].ToString());

                    cc.Add(c);
                }
                cn.Close();
                return cc;
            }

            //add session plainte
            public void add_session(Session_Plainte c)
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlTransaction tx = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into session_plainte(date_session,id_plainte,decision)values(@b,@z,@e)", cn);
                    SqlParameter p1 = new SqlParameter("@b", c.Date_session);
                    SqlParameter p2 = new SqlParameter("@z", c.Id_plainte);
                    SqlParameter p3 = new SqlParameter("@e", c.Decision);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);

                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    cn.Close();
                    MessageBoxManager.OK = "حسنا";
                    MessageBoxManager.Register();
                    DialogResult dr = MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK);
                    MessageBoxManager.Unregister();
                    //MessageBox.Show("تمت الإضافة بنجاح");
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    MessageBox.Show(e.Message);
                }

            }

            // update session palinte
            public void update_session(Session_Plainte sp)
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlTransaction tx = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("update session_plainte set decision=@d,date_session=@ds,id_plainte=@ip where id_session=@is", cn);
                    SqlParameter p0 = new SqlParameter("@d", sp.Decision);
                    SqlParameter p1 = new SqlParameter("@ds", sp.Date_session);
                    SqlParameter p2 = new SqlParameter("@ip", sp.Id_plainte);
                    SqlParameter p3 = new SqlParameter("@is", sp.Id_session);
                    cmd.Parameters.Add(p0);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
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
            //delete session plainte
            public void deleteSessionPlainte(int idsession)
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) { cn.Open(); }
                    SqlCommand command = new SqlCommand("DELETE FROM session_plainte WHERE id_session = '" + idsession + "'", cn);
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }

            }

        }
