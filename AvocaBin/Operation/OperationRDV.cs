using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AvocaBin.Models.RDV;
using AvocaBin.Operation;
using System.Data;

namespace AvocaBin
{
    class RDVOperations
    {
        SqlConnection cn = connection.getConnection();

        // méthode d'ajoute d'un RDV :

        public void AddRDV(RDV r)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into RDV(CinRDV,DateRDV,Nom,Cause) values(@id,@date,@nom,@cause)";
                SqlParameter p1 = new SqlParameter("@id", r.CinRDV1);
                SqlParameter p2 = new SqlParameter("@date", r.DateRDV1);
                SqlParameter p3 = new SqlParameter("@nom", r.Nom1);
                SqlParameter p4 = new SqlParameter("@cause", r.Cause1); ;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("لقد تم اضافة الموعد بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            cn.Close();
        }


        public void UpdateRDV(string cin)
        {
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            try
            {
                RDV r = new RDV();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update RDV set DateRDV = @date , Nom= @nom , Cause = @cause where CinRDV=" + cin + "";
                cmd.Connection = cn;
                SqlParameter p2 = new SqlParameter("@date", r.DateRDV1);
                SqlParameter p3 = new SqlParameter("@nom", r.Nom1);
                SqlParameter p4 = new SqlParameter("@cause", r.Cause1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("لقد ثم التعديل بنجاح ", "التعديل", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteRDV(string cin)
        {
            try
            {
                RDV r = new RDV();
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from RDV where CinRDV = " + cin + "";
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("لقد ثم الحدف بنجاح ", "الحدف", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public List<RDV> listeRDV()
        {
            List<RDV> LesRDV = new List<RDV>();
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from RDV ";
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RDV r = new RDV();
                    r.CinRDV1 = dr["CinRDV"].ToString();
                    r.DateRDV1 = Convert.ToDateTime(dr["DateRDV"]);
                    r.Nom1 = dr["Nom"].ToString();
                    r.Cause1 = dr["Cause"].ToString();
                    LesRDV.Add(r);
                }
                dr.Close();
                cn.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return LesRDV;
        }

        public List<RDV> GetRDVByNomAndCIN(string cnf)
        {
            List<RDV> ListeDesRecherche = new List<RDV>();
            try
            {

                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from RDV where CinRDV like @a or Nom like @b";
                cmd.Connection = cn;
                SqlParameter p1 = new SqlParameter("@a", "%" + cnf + "%");
                SqlParameter p2 = new SqlParameter("@b", "%" + cnf + "%");
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RDV r = new RDV();
                    r.CinRDV1 = dr["CinRDV"].ToString();
                    r.DateRDV1 = Convert.ToDateTime(dr["DateRDV"]);
                    r.Nom1 = dr["Nom"].ToString();
                    r.Cause1 = dr["Cause"].ToString();
                }
                dr.Close();
                cn.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return ListeDesRecherche;
        }

        public List<RDV> SearchByDateDebutAndDateFin(DateTime dd, DateTime df)
        {
            List<RDV> ListeDate = new List<RDV>();

            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from RDV where DateRDV between '"+dd+"' and '"+df+"'";
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    RDV r = new RDV();
                    r.CinRDV1 = dr["CinRDV"].ToString();
                    r.DateRDV1 = Convert.ToDateTime(dr["DateRDV"]);
                    r.Nom1 = dr["Nom"].ToString();
                    r.Cause1 = dr["Cause"].ToString();
                    ListeDate.Add(r);
                    
                }
                
                dr.Close();
                cn.Close();
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
            return ListeDate;
                
        }



        internal void SearchByDateDebutAndDateFin()
        {
            throw new NotImplementedException();
        }
    }
 

}


