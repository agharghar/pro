using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AvocaBin
{
    class connection
    {
        public static SqlConnection getConnection()
        {
            string mode = Properties.Settings.Default.Mode;

            if (mode=="SQL")
            {
                SqlConnection cn = new SqlConnection(@"Data Source=" + Properties.Settings.Default.Server + ";Persist Security Info=True;Initial Catalog=" + Properties.Settings.Default.DataBase + "; User Id=" + Properties.Settings.Default.ID + "; password= " + Properties.Settings.Default.PassWord + ";MultipleActiveResultSets=true");
                return cn;
            }
            else
            {
                SqlConnection cn = new SqlConnection(@"Data Source="+Properties.Settings.Default.Server+";Initial Catalog="+Properties.Settings.Default.DataBase+"; Integrated Security=true;MultipleActiveResultSets=true");
                return cn;
            }
        }
    }
}
