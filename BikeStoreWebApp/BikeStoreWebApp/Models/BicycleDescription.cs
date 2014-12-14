using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp.Models
{
    public class BicycleDescription: spGetProductDetails_Result
    {
        protected BikeStoreWebApp_Database.ist440grp1Entities1 db;

        public List<spGetProductDetails_Result> GetBicycleDetailForDescription(int productID)
        {
            using (db = new ist440grp1Entities1())
            {
                var sql = "exec spGetProductDetails @productId";
                var idParam = new SqlParameter("productId", productID);
                var query = db.Database.SqlQuery<spGetProductDetails_Result>(sql, idParam);
                var description = query.ToList();

                return description;
            }
        }
    }
}