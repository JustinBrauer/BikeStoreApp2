using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes
{
    public class Order1 : IOrder
    {
        ////SHIPPING METHOD????
        //protected enum Payment { stripe, paypal }
        //protected enum Status { inprocess, approved, rejected, shipped, cancelled }
        //protected int orderID { get; set; }
        //protected int trackingNum { get; set; }
        //protected Status orderStatus { get; set; }
        //protected Payment method { get; set; }
        //protected DateTime orderDateTime { get; set; }
        public IList<BikeStoreWebApp_Database.PurchaseOrderDetail> GetOrderedProducts(int OrderID)
            {
                //using (ist440grp1Entities1 n = new BikeStoreApp_Database.ist440grp1Entities1())
                //{
                //    PurchaseOrderDetail OrderTbl = n.PurchaseOrderDetails.Find(OrderID);
                //    return OrderTbl;
                //};
                return null;
            }


            public bool IsAccountHolder()
            {
                //var prods = new List<int>();
                //prods.Add(OrderTbl.ProductID);
                //return prods.ToList();
                return true;
            }

            public decimal CalculateTotal()
            {
                return 0.00m;
            }

            public void SendConfirmationEmail()
            {

        }

            public void UpdateOrder()
            {

            }
        public void CreateNewOrder()    //place this in the order class?
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query
            //switch case based on the type of user
            //1: customer
            //insert into database/table customer id, first name, last name, address, email, product id, quantity, color
            //or hit on a sprocfcc

            //if successful -- SendEmailConfirmation()
            //if successful -- return true
            //else return false
            //else return false

            //2: account holder/administrator
            //insert into database/table customer id, first name, last name, address, email, product id, quantity, color
            

            //if successful -- SendEmailConfirmation()
            //if successful -- return true
            //else return false
            //else return false
        }

        public void DeleteOrder()
        {
            //verify that the user is logged in
            //make sure that the database/table is connected
            //if logged in -- double check the EntityID
            //ReadOrder()
            //check the status of the order
            //if order is unapproved/in process
            //dropOrder
            //else cannot dropOrder
        }

        public void ReadOrder()
        {
            //verify that the user is logged in
            //make sure that the database/table is connected
            //if logged in -- double check that EntityID
            //get a order based entity id, and date? product name? 
        }
    }
}
