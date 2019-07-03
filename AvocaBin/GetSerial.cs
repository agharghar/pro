using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AvocaBin
{
    class GetSerial
    {

       static String sn="";

        // Fonction qui return Serial Number :
        public static String GetSerialNumber()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("wmic bios get serialnumber");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            while (cmd.StandardOutput.EndOfStream.Equals(false))
            {
                String next = cmd.StandardOutput.ReadLine();

                if ("SerialNumber".Equals(next.Trim()))
                {
                    cmd.StandardOutput.ReadLine();
                    sn = "pp"+cmd.StandardOutput.ReadLine().Trim()+"aa";
                    break;
                }
            }
           

            return GetMd5Hash(MD5.Create(), sn);
        }

        static String GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }   







    }
}
