using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Interfaces
{
    public interface IShoppingCart
    {
        /// <summary>
        /// Method Stub:
        /// -This shall calculate each product's cost (this will include the amount of each product).
        /// -This shall just be for each individual product that is in the shoppin cart.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodName"></param>
        /// <returns></returns>
        decimal CalculateProductTotal(int prodId, string prodName = "");

        /// <summary>
        /// Method Stub:
        /// -This Method shall calculate the carts total(adding the individual product totals up)
        /// -This shall return the total cost of the items in the cart
        /// </summary>
        /// <param name="ProdTotals"></param>
        /// <returns></returns>
        decimal CalculateCartTotalwithTax(List<decimal> ProdTotals);

        /// <summary>
        /// Method Stub:
        /// -This method shall be used to to get information about the products that are being added.
        /// -It shall return a list of product information for each individual product that is in the shopping cart.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodName"></param>
        /// <returns></returns>
        IList<BikeStoreWebApp_Database.Product> GetProductInfo(int prodId, string prodName = "");

        /// <summary>
        /// Method Stub:
        /// -This method shall determine if the cart is empty or there is still items that have not been ordered yet that are sitting in the shopping Cart.
        /// -It shall return a true o=r false depending on it if is empty or not.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Method Stub:
        /// -This method shall find out if this shopping cart order is being created by a guest on the site. 
        /// -This method shall determine if we should prepopulate the address Fields(Shipping / Billing)
        /// </summary>
        /// <returns></returns>
        bool IsGuestCreateCart();
        
        /// <summary>
        /// Method Stub:
        /// -This Will get the sales Tax for the regain that customer is in.
        /// -This Tax percentage + amount shal be displayed on the screen
        /// </summary>
        void DisplayStateTax();

        /// <summary>
        /// Method Stub:
        /// -This method will update the shopping cart table with any products that get added to the shopping cart.
        /// -This should be called whenever the "Add to Cart" button is pushed
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodQuantity"></param>
        void AddProductInCart(int prodId, int prodQuantity);

        /// <summary>
        /// Method Stub:
        /// -This method shall updated the about quantity per product that is the cart.
        /// -This method should be called when adding a product to the cart, as well as when updating the carts individual product quantity.
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="prodQuantity"></param>
        void EditProductQtyInCart(int prodId, int prodQuantity);

        /// <summary>
        /// Method Stub:
        /// -This method will search to see if there is same Named product but with a Different Color to it.
        /// -Note: some of the products don't have specified colors to themselves
        /// </summary>
        /// <param name="prodId"></param>
        void EditProductColorInCart(int prodId);

        /// <summary>
        /// Method Stub:
        /// -This method delete a product from the cart.
        /// -there will be two ways that this can happen 1.) click the delete button next to the product, or 2.) the quantity goes down to zero.
        /// </summary>
        /// <param name="prodId"></param>
        void DeleteProductInCart(int prodId);

    }
}
