using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes
{
    public class Logger
    {
        public void LogException(string source, Exception exc)
        {
            //Include Enterprice logic foe logging Exceptions
            //Get the absolute path to the Log File
            string LogFile = "/App_Data/ErrorLog(Mock).txt";

            //Setup too the Log Fiel location
            LogFile = HttpContext.Current.Server.MapPath(LogFile);

            //Open the log File for append and write the log
            StreamWriter sw = new StreamWriter(LogFile, true);
            sw.WriteLine("************ {0} **************", DateTime.Now);
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception type:  ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception:  ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }// End of inner Expection If statement


            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Log(string Message)
        {
            //Include Enterprice logic foe logging Exceptions
            //Get the absolute path to the Log File
            string LogFile = "/App_Data/ErrorLog(Mock).txt";

            //Setup too the Log Fiel location
            LogFile = HttpContext.Current.Server.MapPath(LogFile);

            //Open the log File for append and write the log
            StreamWriter sw = new StreamWriter(LogFile, true);
            sw.WriteLine("************ {0} **************", DateTime.Now);
            sw.WriteLine("Information: " + Message);
            sw.Close();
        }
    }
}