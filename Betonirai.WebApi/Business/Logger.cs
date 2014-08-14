using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Betonirai.WebApi.Business
{
    public sealed class Logger
    {
        public static void LogExeption(Exception ex)
        {
            using (StreamWriter wr = new StreamWriter("txtexceptionLog.txt", true))
            {
                wr.WriteLine(DateTime.Now + " : " + ex.Message);
            }
        }

        public static void LogMessage(string text)
        {
            using (StreamWriter wr = new StreamWriter("log.txt", true))
            {
                wr.WriteLine(DateTime.Now + " : " + text);
            }
        }
    }
}