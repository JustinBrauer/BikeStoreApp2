using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;


namespace BikeStoreWebApp_Backend.Interfaces
{
    /// <summary>
    /// General interface for the Customer class which holds all of the methods that a Customer would utlized. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICustomer<T> where T : class
    {
        IList<T> GetCustomerInfo(int id);
        string Register(string first, string last, string email, string pass);
        bool Login(string email, string pass);
        bool DeleteAccount(int id);
        bool ChangeAccountLastName(int id, string last);
        IList<T> ReadOrderHistory(int id);
        void LogOff(); 
    }
}
