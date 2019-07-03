using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AvocaBin
{
    class notification
    {
        SqlConnection cn = connection.getConnection();
        SqlCommand cmd = new SqlCommand();

        public string id { set; get; }
        public string idCause { set; get; }
        public string typeFile { set; get; }
        public DateTime date { set; get; }
        public string numdecision { set; get; }
        public string decisionFinal { set; get; }
        public DateTime dateDecision { set; get; }
        public string idClient { set; get; }
        public string idAdv { set; get; }
        public string tribunal { set; get; }
        public string typeCause { set; get; }
        public string ville { set; get; }
        public string commisaireJudiciaire { set; get; }
        public string note { set; get; }
        public string num_cause_tribunal { get; set; }

        public string save()
        {
            cmd.CommandText = "insert into notification values(@id,@idCause,@date,@numDec,@deciFin,@dateDec,@idCl,@idAd,@trib,@typeCa,@ville,@commi,@note,@typeFile)";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@idCause", idCause);
            cmd.Parameters.AddWithValue("@date", date.ToShortDateString());
            cmd.Parameters.AddWithValue("@numDec", numdecision);
            cmd.Parameters.AddWithValue("@deciFin", decisionFinal);
            cmd.Parameters.AddWithValue("@dateDec", dateDecision.ToShortDateString());
            cmd.Parameters.AddWithValue("@idCl", idClient);
            cmd.Parameters.AddWithValue("@idAd", idAdv);
            cmd.Parameters.AddWithValue("@trib", tribunal);
            cmd.Parameters.AddWithValue("@typeCa", typeCause);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.Parameters.AddWithValue("@commi", commisaireJudiciaire);
            cmd.Parameters.AddWithValue("@note", note);
            cmd.Parameters.AddWithValue("@typeFile", typeFile);
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.ExecuteNonQuery();
            string t = id;
            cn.Close();
            return t;
        }

        public static List<notification> find(string word)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select n.* from notification n where n.idCause=@word or n.idClient = @word or n.id = @word or n.idCause = @word";
            cmd.Parameters.AddWithValue("@word", word);
            dr = cmd.ExecuteReader();
            List<notification> listCl = new List<notification>();
            while (dr.Read())
            {
                notification no = new notification();
                no.id = dr["id"].ToString();
                no.idCause = dr["idCause"].ToString();
                no.numdecision = dr["numDecision"].ToString();
                no.decisionFinal = dr["DecisionFinal"].ToString();
                no.date = (DateTime)dr["date"];
                no.dateDecision = (DateTime)dr["dateDecision"];
                no.idClient = dr["idClient"].ToString();
                no.idAdv = dr["idAdv"].ToString();
                no.tribunal = dr["tribunal"].ToString();
                no.typeCause = dr["typeCause"].ToString();
                no.ville = dr["ville"].ToString();
                no.commisaireJudiciaire = dr["commisaireJudiciaire"].ToString();
                no.note = dr["note"].ToString();
                no.typeFile = dr["typeFile"].ToString();
                //no.num_cause_tribunal = dr["num_cause_tribunal"].ToString();
                listCl.Add(no);
            }
            dr.Close(); dr.Dispose(); cn.Close();
            return listCl;
        }

        public static void delete(string word)
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete notification where id=@id";
            cmd.Parameters.Add("@id", word);
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.ExecuteNonQuery();
            cn.Close();
            cmd.Parameters.Clear();
        }

        public static notification findById(string id)
        {
            notification no = new notification();
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.Connection = cn;
            cmd.CommandText = "select * from notification where id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            dr = cmd.ExecuteReader();
            dr.Read();
            no.id = dr["id"].ToString();
            no.idCause = dr["idCause"].ToString();
            no.numdecision = dr["numDecision"].ToString();
            no.decisionFinal = dr["DecisionFinal"].ToString();
            no.date = (DateTime)dr["date"];
            no.dateDecision = (DateTime)dr["dateDecision"];
            no.idClient = dr["idClient"].ToString();
            no.idAdv = dr["idAdv"].ToString();
            no.tribunal = dr["tribunal"].ToString();
            no.typeCause = dr["typeCause"].ToString();
            no.ville = dr["ville"].ToString();
            no.commisaireJudiciaire = dr["commisaireJudiciaire"].ToString();
            no.note = dr["note"].ToString();
            no.typeFile = dr["typeFile"].ToString();
            cn.Close();
            dr.Dispose();
            return no;
        }

        public int update()
        {
            SqlConnection cn = connection.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.Connection = cn;
            cmd.CommandText = "update notification set idCause=@idCause, date=@date, numDecision=@numd, DecisionFinal=@DeciF, dateDecision=@dateD, idClient=@idCl, idAdv=@idAd, tribunal=@tri, typeCause=@typeC, ville=@ville, commisaireJudiciaire=@comm, note=@note, typeFile=@typeF where id=@id";
            cmd.Parameters.AddWithValue("@idCause", idCause);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@numd", numdecision);
            cmd.Parameters.AddWithValue("@DeciF", decisionFinal);
            cmd.Parameters.AddWithValue("@dateD", dateDecision);
            cmd.Parameters.AddWithValue("@idCl", idClient);
            cmd.Parameters.AddWithValue("@idAd", idAdv);
            cmd.Parameters.AddWithValue("@tri", tribunal);
            cmd.Parameters.AddWithValue("@typeC", typeCause);
            cmd.Parameters.AddWithValue("@ville", ville);
            cmd.Parameters.AddWithValue("@comm", commisaireJudiciaire);
            cmd.Parameters.AddWithValue("@note", note);
            cmd.Parameters.AddWithValue("@typeF", typeFile);
            cmd.Parameters.AddWithValue("@id", id);
            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            int t = cmd.ExecuteNonQuery();
            cn.Close();
            return t;
        }
    }
}
