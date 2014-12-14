using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;
using BikeStoreWebApp_Backend.Classes;
using BikeStoreWebApp_Backend.Interfaces;

namespace BikeStoreWebApp_UnitTestProject
{
    [TestClass]
    public class Order_UnitTests
    {
        [TestMethod]
        #region Unit test for an order if it got created and is in the DB
        public void tstOrderExists()
        {
            using (ist440grp1Entities1 en = new ist440grp1Entities1())
            {
                var OrderID = 43659;
                var OrderDetails = en.SalesOrderDetails
                    .Where(x => x.SalesOrderID == OrderID)
                    .Select(x => new {x.ProductID});

                foreach (var OrderItem in OrderDetails)
                {
                    Assert.IsNotNull(OrderItem.ProductID);
                    break;
                }
            }
        }

        [TestMethod]
        public void tstOrderNotExists()
        {
            using (ist440grp1Entities1 en = new ist440grp1Entities1())
            {
                var OrderID = 50000;
                var OrderDetails = en.SalesOrderDetails
                    .Where(x => x.SalesOrderID == OrderID)
                    .Select(x => new { x.ProductID });

                foreach (var OrderItem in OrderDetails)
                {
                    Assert.IsNull(OrderItem.ProductID);
                    break;
                }
            }
        }

        [TestMethod]
        public void tstOrderByValue()
        {
            using (ist440grp1Entities1 en = new ist440grp1Entities1())
            {
                var OrderID = 43659;
                //var OrderDetails = en.SalesOrderDetails
                //.Where(x => x.SalesOrderID == OrderID)
                //.Select(x => new { x.ProductID });

                //foreach (var OrderItem in OrderDetails)
                //{
                //    Assert.IsNotNull(OrderItem.ProductID);
                //    break;
                //}
                long Product = Convert.ToInt64(en.SalesOrderDetails.SqlQuery("SELECT TOP 1 Sales.SalesOrderDetail.ProductID from Sales.SalesOrderDetail where Sales.SalesOrderDetail.SalesOrderID = " + OrderID));
                Assert.IsNotNull(Product);
            }
        }
        #endregion

        [TestMethod]
        public void tstOrderStatus()
        {
            using (ist440grp1Entities1 ent = new ist440grp1Entities1())
            {
                var OrderID = 343;
                var status = from x in ent.SalesOrderHeaders where x.SalesOrderID == OrderID select x.Status;
                Assert.IsNotNull(status);
            }
        }
    }
}
