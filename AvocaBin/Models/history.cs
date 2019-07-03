using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin.Models
{
    class history
    {
        /*
         * Ahmed Ouberka
         * date : 22/07/2017
         * email : ahmedouberka@hotmail.com
        */


        //this function is for logging every operation happens in the app and to know who did it
        public static void AddHistory(string subject,string operation,string idRow)
        {
            string author = Environment.MachineName;
            DateTime date = DateTime.Now;
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "insert into history values(@type,@op,@auth,@d,@id)";
            cmd.Parameters.Add("@type", subject);
            cmd.Parameters.Add("@op", operation);
            cmd.Parameters.Add("@auth", author);
            cmd.Parameters.Add("@d", date.ToShortDateString());
            cmd.Parameters.Add("@id", idRow);
            cmd.ExecuteNonQuery();
            
            cn.Close();

            cmd.Parameters.Clear();
        }

        internal static void AddHistory(string p1, string p2)
        {
            throw new NotImplementedException();
        }
    }
}
