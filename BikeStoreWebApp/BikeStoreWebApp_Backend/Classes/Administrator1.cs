using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes
{
    public class Administrator
    {
        protected enum AcctType { SystemAdmin, StoreManager }

        protected int adminID { get; set; }
        protected AcctType adminType { get; set; }
        protected string email { get; set; }
        protected string password { get; set; }
    }
}