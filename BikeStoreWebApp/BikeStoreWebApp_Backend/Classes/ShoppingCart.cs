using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes
{
    public class ShoppingCart : IShoppingCart
    {
        //protected int customerID { get; set; }
        //public decimal subTotal { get; set; }
        //public decimal salesTax { get; set; }
        //public decimal totalPrice { get; set; }

        /// <summary>
        /// Implementation Method:
        /// -This shall calculate each product's cost (this will include the amount of each product).
        /// -This shall just be for each individual product that is in the shoppin cart.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodName"></param>
        /// <returns></returns>
        public decimal CalculateProductTotal(int prodId, string prodName = "")
        {
            return 0.00M;
        }

        /// <summary>
        /// Implementation Method:
        /// -This Method shall calculate the carts total(adding the individual product totals up)
        /// -This shall return the total cost of the items in the cart
        /// </summary>
        /// <param name="ProdTotals"></param>
        /// <returns></returns>
        public decimal CalculateCartTotalwithTax(List<decimal> ProdTotals)
        {
            
            return 0.00m;
        }

        /// <summary>
        /// Implementation Method:
        /// -This method shall be used to to get information about the products that are being added.
        /// -It shall return a list of product information for each individual product that is in the shopping cart.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodName"></param>
        /// <returns></returns>
        public IList<BikeStoreWebApp_Database.Product> GetProductInfo(int prodId, string prodName = "")
        {
            return null;
        }

        /// <summary>
        /// Implementation Method:
        /// -This method shall determine if the cart is empty or there is still items that have not been ordered yet that are sitting in the shopping Cart.
        /// -It shall return a true o=r false depending on it if is empty or not.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return true;
        }

        /// <summary>
        /// Implementation Method:
        /// -This method shall find out if this shopping cart order is being created by a guest on the site. 
        /// -This method shall determine if we should prepopulate the address Fields(Shipping / Billing)
        /// </summary>
        /// <returns></returns>
        public bool IsGuestCreateCart()
        {
            return true;
        }

     
        /// <summary>
        /// Implementation Method:
        /// -This method will update the shopping cart table with any products that get added to the shopping cart.
        /// -This should be called whenever the "Add to Cart" button is pushed
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodQuantity"></param>
        public void AddProductInCart(int prodId, int prodQuantity)
        {

        }

        /// <summary>
        /// Implementation Method:
        /// -This method shall updated the about quantity per product that is the cart.
        /// -This method should be called when adding a product to the cart, as well as when updating the carts individual product quantity.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodQuantity"></param>
        public void EditProductQtyInCart(int prodId, int prodQuantity)
        {

        }

        /// <summary>
        /// Implementation Method:
        /// -This method will search to see if there is same Named product but with a Different Color to it.
        /// -Note: some of the products don't have specified colors to themselves
        /// </summary>
        /// <param name="prodId"></param>
        public void EditProductColorInCart(int prodId)
        {

        }

        public void AddProductInCart()
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query
            //send in product id through button click
            //return product id, name, qty, color into the cart
        }

        public void EditProductQtyInCart()
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query 
            //through product id, edit qty numner in cart
            //return true if it goes through
        }

        public void EditProductColorInCart()
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query
            //through product id, edit color in cart
            //return true if it goes through
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodName"></param>
        /// <returns></returns>
        public void DeleteProductInCart(int prodId)
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query   
            //through product id, remove item from cart
        }

        //public bool IsEmpty()
        //{
        //    //Make a connection to the database/specific table
        //    //create a var variable and make a query
        //    //check is there are any product ids in the cart
        //    //return true is there is nothing
        //    //else return false;
        //}

        //public bool NewCustomer()
        //{
        //    //Make a connection to the database/specific table
        //    //create a var variable and make a query        
        //}

        //public decimal CalculateSubTotal()
        //{
        //    //Make a connection to the database/specific table
        //    //create a var variable and make a query        
        //}

        public void DisplayStateTax()
        {
            //Make a connection to the database/specific table
            //create a var variable and make a query        
        }

    }
}