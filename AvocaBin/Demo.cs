using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Globalization;

namespace AvocaBin
{
    class Demo
    {

        public static DateTime DateVersionDemo()
        {
            DateTime localDateTime = new DateTime();
            bool test = false;
            while (test == false)
            {
                try
                {
                    TcpClient client = new TcpClient("time.nist.gov", 13);
                    StreamReader streamReader = new StreamReader(client.GetStream());
                    var response = streamReader.ReadToEnd();
                    if (response.Length != 0)
                    {
                        var utcDateTimeString = response.Substring(7, 17);
                        localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                        test = true;
                    }
                }
                catch (Exception ee)
                {
                    if (ee is SocketException || ee is IOException) { }
                }
            }
            DateTime dt1 = localDateTime;
            TimeSpan oneDay = TimeSpan.FromDays(30);
            DateTime demain = dt1 + oneDay;
            return demain;
        }

    }
}
