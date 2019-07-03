using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvocaBin.Controller;
using System.Net.Sockets;
using System.IO;
using System.Globalization;

namespace AvocaBin
{
    class  DateExpiration
    {
        public static DateTime DateExpirationAvocaBine()
        {
            DateTime localDateTime = DateTime.Now;
            //bool test = false;
            //while (test == false)
            //{
            //    try
            //    {
            //        TcpClient client = new TcpClient();
            //        client.Connect("time.nist.gov", 13);
            //        StreamReader streamReader = new StreamReader(client.GetStream());
            //        var response = streamReader.ReadToEnd();
            //        if (response.Length != 0)
            //        {
            //            var utcDateTimeString = response.Substring(7, 17);
            //            localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            //            test = true;
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        if (ee is SocketException || ee is IOException) { }
            //    }
            //}
            DateTime dt1 = localDateTime;
            TimeSpan oneDay = TimeSpan.FromDays(365);
            DateTime demain = dt1 + oneDay;
            return demain;
        }
    }
}
