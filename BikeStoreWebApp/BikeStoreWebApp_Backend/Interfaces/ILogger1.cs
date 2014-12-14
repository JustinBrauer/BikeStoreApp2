using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BikeStoreWebApp_Backend.Classes;

namespace BikeStoreWebApp_Backend.Interfaces
{
    public interface ILogger
    {
        void LogException(string source, Exception exc);
        void Log(string Message);
    }
}
