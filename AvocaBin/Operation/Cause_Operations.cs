using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AvocaBin.Models.cause;
using System.Windows.Forms;
using AvocaBin.Models;
using System.Data;

namespace AvocaBin.Operation
{
    class Cause_Operations
    {
        SqlConnection cn = connection.getConnection();

        //
        //
        //client cause
        //
        //
        //add client cause
        public void add_client_cause(client_cause c)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into client_cause(type_client,cin,nom,telephone,representant_legal,registre_commerce,adresse)values(@b,@z,@e,@r,@t,@y,@u)", cn);
                SqlParameter p1 = new SqlParameter("@b", c.Type_client);
                SqlParameter p2 = new SqlParameter("@z", c.Cin);
                SqlParameter p3 = new SqlParameter("@e", c.Nom);
                SqlParameter p4 = new SqlParameter("@r", c.Telephone);
                SqlParameter p5 = new SqlParameter("@t", c.Representant_legal);
                SqlParameter p6 = new SqlParameter("@y", c.Registre_commerce);
                SqlParameter p7 = new SqlParameter("@u", c.Adresse);
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
                //Console.WriteLine(e.Message);
            }

        }

        //delete client

        public void deleteClient_cause(int id_client_cause)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE FROM client_cause WHERE id_client_cause="+id_client_cause, cn);
                cmd.ExecuteNonQuery();
                
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم الحدف بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
               // MessageBox.Show("تم الحدف بنجاح ");
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
        //update client cause
        public void update_client_cause(client_cause cc)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update client_cause set type_client=@a,nom=@e,telephone=@r,representant_legal=@t,adresse=@u,registre_commerce=@x,cin=@z where id_client_cause=@m", cn);
                SqlParameter c0 = new SqlParameter("@m", cc.Id_client_cause);
                SqlParameter c1 = new SqlParameter("@a", cc.Type_client);
                SqlParameter c2 = new SqlParameter("@z", cc.Cin);
                SqlParameter c3 = new SqlParameter("@e", cc.Nom);
                SqlParameter c4 = new SqlParameter("@r", cc.Telephone);
                SqlParameter c5 = new SqlParameter("@t", cc.Representant_legal);
                SqlParameter c6 = new SqlParameter("@x", cc.Registre_commerce);
                SqlParameter c7 = new SqlParameter("@u", cc.Adresse);
                cmd.Parameters.Add(c0);
                cmd.Parameters.Add(c1);
                cmd.Parameters.Add(c2);
                cmd.Parameters.Add(c3);
                cmd.Parameters.Add(c4);
                cmd.Parameters.Add(c5);
                cmd.Parameters.Add(c6);
                cmd.Parameters.Add(c7);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();

                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
               // MessageBox.Show("تم التعديل بنجاح ");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
            }
        }
        //all client cause
        public List<client_cause> getAllClients_cause()
        {
            List<client_cause> cc = new List<client_cause>();
            if (cn.State==System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
            //cn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM client_cause", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                client_cause c = new client_cause();
                c.Id_client_cause=(int)reader["id_client_cause"];
                c.Type_client = (string)reader["type_client"];
                c.Cin = (string)reader["cin"];
                c.Nom = (string)reader["nom"];
                c.Telephone = (string)reader["telephone"];
                c.Representant_legal = (string)reader["representant_legal"];
                c.Registre_commerce = (string)reader["registre_commerce"];
                c.Adresse = (string)reader["adresse"];
                cc.Add(c);
            }
            reader.Close();
            cn.Close();
            return cc;
        }
        //search client cause
        public List<client_cause> searchclient_cause(string id)
        {
            List<client_cause> cc = new List<client_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM client_cause where  cin like'" + id + "%' or registre_commerce like'" + id + "%' or nom like'"+id+"%'", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                client_cause c = new client_cause();
                c.Id_client_cause = (int)reader["id_client_cause"];
                c.Type_client = (string)reader["type_client"];
                c.Cin = (string)reader["cin"];
                c.Nom = (string)reader["nom"];
                c.Telephone = (string)reader["telephone"];
                c.Representant_legal = (string)reader["representant_legal"];
                c.Registre_commerce = (string)reader["registre_commerce"];
                c.Adresse = (string)reader["adresse"];
                cc.Add(c);
            }
            cn.Close();
            return cc;
        }
        //
        //
        //
        //cause
        //
        //add cause 

        public bool IsNumeric(string Nombre)
        {
            try
            {
                int.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void add_cause(cause ca,Session se)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            SqlCommand Command = new SqlCommand("SELECT * FROM cause where id_cause='" + ca.Id_cause + "'", cn);
            SqlDataReader reader1 = Command.ExecuteReader();
            Command.Dispose();
            if (reader1.HasRows)
            {
                //MessageBox.Show("existe dans base donnée");
                MessageBoxManager.OK = "حسنا";

                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("هده القضية متواجدة في سجل البيانات", "تنبيه", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();

            }

            else
            {
                Command.Dispose();
                reader1.Close();
                SqlTransaction tx = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into cause(id_cause,date_session,date_creation,id_client,nom_avocat,juge,signe_cause,type_cause,avocat_adv,tribunal,id_adv,poursuite,ville,num_cause_tribunal,commisaire_judiciaire,appel,duree,total_paiement,etat)values(@a,@z,getdate(),@e,@r,@t,@y,@u,@i,@o,@p,@q,@s,@d,@f,@g,@h,@n,'non archivé')", cn);
                    SqlCommand cm1 = new SqlCommand("insert into sessione(date_session,id_cause,decision)values(@w,@x,@c)", cn);
                    SqlParameter p0 = new SqlParameter("@a", ca.Id_cause);
                    SqlParameter p1 = new SqlParameter("@z", ca.Date_session);
                    SqlParameter p2 = new SqlParameter("@e", ca.Id_client);
                    SqlParameter p3 = new SqlParameter("@r", ca.Nom_avocat);
                    SqlParameter p4 = new SqlParameter("@t", ca.Juge);
                    SqlParameter p5 = new SqlParameter("@y", ca.Signe_cause);
                    SqlParameter p6 = new SqlParameter("@u", ca.Type_cause);
                    SqlParameter p7 = new SqlParameter("@i", ca.Avocat_adversaire);
                    SqlParameter p8 = new SqlParameter("@o", ca.Type_tribunal);
                    SqlParameter p9 = new SqlParameter("@p", ca.Id_adv);
                    SqlParameter p10 = new SqlParameter("@q", ca.Poursuite);
                    SqlParameter p11 = new SqlParameter("@s", ca.Ville);
                    SqlParameter p12 = new SqlParameter("@d", ca.Num_cause_tribunal);
                    SqlParameter p13 = new SqlParameter("@f", ca.Commisaire_judiciaire);
                    SqlParameter p14 = new SqlParameter("@g", ca.Appel);
                    SqlParameter p18 = new SqlParameter("@h", ca.Duree);
                    SqlParameter p19 = new SqlParameter("@n", ca.Montant);
                    //SqlParameter p20 = new SqlParameter("@b", ca.Montant);
                    //SqlParameter p20 = new SqlParameter("@v", "getdate()");
                    
                    SqlParameter p15 = new SqlParameter("@w", se.Date_session);
                    SqlParameter p16 = new SqlParameter("@x", se.Id_cause);
                    SqlParameter p17 = new SqlParameter("@c", se.Decision);
                    

                    
                    cmd.Parameters.Add(p0);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);
                    cmd.Parameters.Add(p13);
                    cmd.Parameters.Add(p14);
                    cmd.Parameters.Add(p18);
                    cmd.Parameters.Add(p19);

                   // cmd.Parameters.Add(p20);
                    cm1.Parameters.Add(p15);
                    cm1.Parameters.Add(p16);
                    cm1.Parameters.Add(p17);
                    cmd.Transaction = tx;
                    cm1.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    cm1.ExecuteNonQuery();
                    tx.Commit();
                    
                    //MessageBox.Show("تمت الإضافة بنجاح");

                    MessageBoxManager.OK = "حسنا";

                    MessageBoxManager.Register();
                    DialogResult dr = MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK);
                    MessageBoxManager.Unregister();

                }
                catch (Exception e)
                {
                    tx.Rollback();
                    MessageBox.Show(e.Message);
                }

            }
            cn.Close();
        }
        //delete cause
        public void deleteCause(String id_cause)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE  FROM cause WHERE id_cause ='"+id_cause+"'", cn);
              //  SqlCommand cmd1 = new SqlCommand("delete from sessione where id_cause='" + id_cause + "'", cn);
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                //MessageBox.Show("تم الحدف بنجاح");
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم الحدف بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
        //update cause
        public void updateCause(cause c)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update cause set date_session=@a,id_client=@z,nom_avocat=@e,juge=@r,signe_cause=@t,type_cause=@y,avocat_adv=@u,tribunal=@i,id_adv=@o,poursuite=@p,ville=@q,num_cause_tribunal=@s,commisaire_judiciaire=@d,appel=@f,duree=@h where id_cause=@x", cn);
                SqlParameter c1 = new SqlParameter("@a", c.Date_session);
                SqlParameter c2 = new SqlParameter("@z", c.Id_client);
                SqlParameter c3 = new SqlParameter("@e", c.Nom_avocat);
                SqlParameter c4 = new SqlParameter("@r", c.Juge);
                SqlParameter c5 = new SqlParameter("@t", c.Signe_cause);
                SqlParameter c6 = new SqlParameter("@y", c.Type_cause);
                SqlParameter c7 = new SqlParameter("@u", c.Avocat_adversaire);
                SqlParameter c8 = new SqlParameter("@i", c.Type_tribunal);
                SqlParameter c9 = new SqlParameter("@o", c.Id_adv);
                SqlParameter c10 = new SqlParameter("@p", c.Poursuite);
                SqlParameter c11= new SqlParameter("@q", c.Ville);
                SqlParameter c12= new SqlParameter("@s", c.Num_cause_tribunal);
                SqlParameter c13= new SqlParameter("@d", c.Commisaire_judiciaire);
                SqlParameter c14= new SqlParameter("@f", c.Appel);
                SqlParameter c16 = new SqlParameter("@h", c.Duree);
                SqlParameter c15 = new SqlParameter("@x", c.Id_cause);
                
                cmd.Parameters.Add(c1);
                cmd.Parameters.Add(c2);
                cmd.Parameters.Add(c3);
                cmd.Parameters.Add(c4);
                cmd.Parameters.Add(c5);
                cmd.Parameters.Add(c6);
                cmd.Parameters.Add(c7);
                cmd.Parameters.Add(c8);
                cmd.Parameters.Add(c9);
                cmd.Parameters.Add(c10);
                cmd.Parameters.Add(c11);
                cmd.Parameters.Add(c12);
                cmd.Parameters.Add(c13);
                cmd.Parameters.Add(c14);
                cmd.Parameters.Add(c15);
                cmd.Parameters.Add(c16);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                //MessageBox.Show("تم التعديل بنجاح ");
                MessageBoxManager.OK = "حسنا";

                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
            }

        }
        //
        //
        //piece jointe cause
        //
        //add piece jointe cause
        public void add_piece_jointe_cause(PJ_cause p)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into PJ_cause(photo,titre,date_enregistrement,id_cause)values(@b,@z,@e,@r)", cn);
                SqlParameter p1 = new SqlParameter("@b", p.Photo);
                SqlParameter p2 = new SqlParameter("@z", p.Titre);
                SqlParameter p3 = new SqlParameter("@e", p.Date_enregistrement);
                SqlParameter p4 = new SqlParameter("@r", p.Id_cause);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                //MessageBox.Show("تمت الإضافة بنجاح");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
            }

        }
        //all piece jointe cause
        public List<PJ_cause> getAllPieceJointe()
        {
            List<PJ_cause> p = new List<PJ_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PJ_cause", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PJ_cause c = new PJ_cause();
                c.Id_pj_cause = (int)reader["id_pj"];
                c.Id_cause = (string)reader["id_cause"];
                c.Photo = (byte[])reader["photo"];
                c.Titre = (string)reader["titre"];
                c.Date_enregistrement = (DateTime)reader["date_enregistrement"];

                p.Add(c);
            }
            reader.Close();
            cn.Close();
            return p;
        }
        //piece joint with id
        public List<PJ_cause> getPJ_cause(string id)
        {
            List<PJ_cause> p = new List<PJ_cause>();
            if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PJ_cause where id_cause like'"+id+"%'", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                PJ_cause c = new PJ_cause();
                c.Id_cause = (string)reader["id_cause"];
                c.Photo= (byte[])reader["photo"];
                c.Titre = (string)reader["titre"];
                c.Date_enregistrement = (DateTime)reader["date_enregistrement"];
                c.Id_pj_cause = (int)reader["id_pj"];

                p.Add(c);
            }
            reader.Close();
            cn.Close();
            return p;
        }

        //delete piéce jointe cause
        public void deletePieceJointe_cause(int id_pj)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE FROM PJ_cause WHERE id_pj="+ id_pj, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحدف بنجاح ");
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }

        //
        //
        //adversaire cause
        //
        //
        //add adversaire cause
        public void add_adversaire_cause(adversaire_cause c)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into adversaire_cause(type_adv,cin_adv,nom_adv,adjoint_adv,representant_legal_adv,registre_commerce_adv,adresse_adv)values(@b,@z,@e,@r,@t,@y,@u)", cn);
                SqlParameter p1 = new SqlParameter("@b", c.Type_adversaire);
                SqlParameter p2 = new SqlParameter("@z", c.Cin);
                SqlParameter p3 = new SqlParameter("@e", c.Nom);
                SqlParameter p4 = new SqlParameter("@r", c.Adjoint);
                SqlParameter p5 = new SqlParameter("@t", c.Representant_legal);
                SqlParameter p6 = new SqlParameter("@y", c.Registre_commerce);
                SqlParameter p7 = new SqlParameter("@u", c.Adresse);
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

                MessageBoxManager.OK = "حسنا";
              
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
                
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
            }

        }

        //delete adversaire

        public void deleteAdversaire_cause(int id_Adversaire_cause)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand("DELETE FROM adversaire_cause WHERE id_adversaire_cause = " + id_Adversaire_cause, cn);
                cmd.ExecuteNonQuery();
                MessageBoxManager.OK = "حسنا";
                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم الحدف بنجاح","", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
                //MessageBox.Show("تم الحدف بنجاح ");
                cn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
        }
        //update adversaire cause
        public void update_adversaire_cause(adversaire_cause cc)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("update adversaire_cause set type_adv=@a,nom_adv=@e,representant_legal_adv=@r,adjoint_adv=@f,adresse_adv=@y,cin_adv=@x,registre_commerce_adv=@t where id_adversaire_cause=@m", cn);
                SqlParameter c0 = new SqlParameter("@m", cc.Id_adv_cause);
                SqlParameter c1 = new SqlParameter("@a", cc.Type_adversaire);
                SqlParameter c2 = new SqlParameter("@x", cc.Cin);
                SqlParameter c3 = new SqlParameter("@e", cc.Nom);
                SqlParameter c4 = new SqlParameter("@f", cc.Adjoint);
                SqlParameter c5 = new SqlParameter("@r", cc.Representant_legal);
                SqlParameter c6 = new SqlParameter("@t", cc.Registre_commerce);
                SqlParameter c7 = new SqlParameter("@y", cc.Adresse);
                cmd.Parameters.Add(c0);
                cmd.Parameters.Add(c1);
                cmd.Parameters.Add(c2);
                cmd.Parameters.Add(c3);
                cmd.Parameters.Add(c4);
                cmd.Parameters.Add(c5);
                cmd.Parameters.Add(c6);
                cmd.Parameters.Add(c7);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cn.Close();
                MessageBoxManager.OK = "حسنا";

                MessageBoxManager.Register();
                DialogResult dr = MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK);
                MessageBoxManager.Unregister();
               // MessageBox.Show("تم التعديل بنجاح ");
            }
            catch (Exception e)
            {
                tx.Rollback();
                MessageBox.Show(e.Message);
            }
        }

        //all adversaire cause
        public List<adversaire_cause> getAllAdversaire_cause()
        {
            List<adversaire_cause> cc = new List<adversaire_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM adversaire_cause", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                adversaire_cause c = new adversaire_cause();
                c.Id_adv_cause = (int)reader["id_adversaire_cause"];
                c.Type_adversaire = (string)reader["type_adv"];
                c.Cin = (string)reader["cin_adv"];
                c.Nom = (string)reader["nom_adv"];
                c.Representant_legal = (string)reader["representant_legal_adv"];
                c.Registre_commerce = (string)reader["registre_commerce_adv"];
                c.Adjoint = (string)reader["adjoint_adv"];
                c.Adresse = (string)reader["adresse_adv"];
                cc.Add(c);
            }
            cn.Close();
            return cc;
        }
        //search adversaire cause
        public List<adversaire_cause> searchAdversaire_cause(string id)
        {
            List<adversaire_cause> adv = new List<adversaire_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM adversaire_cause where  cin_adv like'" + id + "%' or registre_commerce_adv like'" + id + "%' or nom_adv like'" + id + "%'", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                adversaire_cause c = new adversaire_cause();
                c.Id_adv_cause = (int)reader["id_adversaire_cause"];
                c.Type_adversaire = (string)reader["type_adv"];
                c.Cin = (string)reader["cin_adv"];
                c.Nom = (string)reader["nom_adv"];
                c.Adjoint = (string)reader["adjoint_adv"];
                c.Representant_legal = (string)reader["representant_legal_adv"];
                c.Registre_commerce = (string)reader["registre_commerce_adv"];
                c.Adresse = (string)reader["adresse_adv"];
                adv.Add(c);
            }
            cn.Close();
            return adv;
        }
        //
        //
        //session
        //
        //add session
        public void add_session(Session c)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlTransaction tx = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into sessione(date_session,id_cause,decision,Phrase_operative)values(@b,@z,@e,@r)", cn);
                SqlParameter p1 = new SqlParameter("@b", c.Date_session);
                SqlParameter p2 = new SqlParameter("@z", c.Id_cause);
                SqlParameter p3 = new SqlParameter("@e", c.Decision);
                SqlParameter p4 = new SqlParameter("@r", c.Phrase_operative1);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                
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
        public List<string> getAllville()
        {
            List<string> pp=new List<string>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ville", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                
                 string ville = (string)reader["ville"];
                

                pp.Add(ville);
            }
            reader.Close();
            cn.Close();
            return pp;
        }

        public List<string> gettribunal() 
        {
            List<string> pp = new List<string>();
            //List<PJ_cause> p = new List<PJ_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM tribunal", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                string tribunal = (string)reader["tribunal"];


                pp.Add(tribunal);
            }
            reader.Close();
            cn.Close();
            return pp;
        }

        //
        //
        //all depot cause
        //
        //

        public List<depot_cause> getDepot_Cause()
        {
            List<depot_cause> dc = new List<depot_cause>();

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("select dp.id_depot,dp.id_cause,cc.nom,ad.nom_adv,dp.num_check,dp.montant from depot_cause dp,adversaire_cause ad,client_cause cc where cc.id_client_cause=dp.id_client_cause and dp.id_adversaire_cause=ad.id_adversaire_cause", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                depot_cause c = new depot_cause();
                c.Id_depot = (int)reader["id_depot"];
                c.Id_cause = (string)reader["id_cause"];
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
        //search depot cause
        //
        //
        //
        //search client cause
        public List<depot_cause> seardepot_caause(string id)
        {
            List<depot_cause> cc = new List<depot_cause>();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            SqlCommand sqlCommand = new SqlCommand("select dc.id_depot,dc.id_cause,cc.nom,ad.nom_adv,dc.num_check,dc.montant from depot_cause dc,client_cause cc,adversaire_cause ad where dc.id_cause like '"+id+"%' and dc.id_adversaire_cause=ad.id_adversaire_cause and dc.id_client_cause=cc.id_client_cause", cn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                depot_cause c = new depot_cause();
                c.Id_depot = (int)reader["id_depot"];
                c.Id_cause = (string)reader["id_cause"];
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
