using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Interfaces
{
    public interface IProduct
    {
        string prodName{ get; set; }
        int prodNum { get; set; }
        decimal prodPrice { get; set; }

        //int ProdQuantity { get; set; }

        /// <summary>
        /// Method Stud::
        /// -This will help you find out what the subcategory is for a particular Product
        /// -ItemNumber is a optional parameter. It will send in a 0 if not specified.
        /// -This will Return a subcategory Name of the single product that was specified.
        /// </summary>
        /// <param name="ItemName"></param>
        /// <param name="ItemNumber"></param>
        /// <returns></returns>        
        string DetermineSubCategoryPerItem(string prodName, int prodId = 0);

        /// <summary>
        /// This will grab all bikes in particular SubCategory
        /// </summary>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        IList<spGetBikesBySubCategory_Result> GetBikes_WithLessInfo(string SubCategory);

        /// <summary>
        /// Method Stub::
        /// -Using either the Item Name or the Item Number(This is optional)
        /// -You will be able to used a SPROC to Capture the quantity of a single Product.
        /// -Also maybe able to use linq to do the same thing.
        /// -This will return the amount of a single product within the DB.
        /// </summary>
        /// <param name="ItemName"></param>
        /// <param name="ItemNumber"></param>
        /// <returns></returns>
        int DetermineStockPerItem(string prodName, int prodId = 0);
        
       /// <summary>
       /// Method Stub::
       /// -This method will be used to pull more information about all Products than what the Product table can give us.
       /// -It will return an Anonymous type (One that I will Specify)
       /// </summary>
       /// <param name="prodId"></param>
       /// <param name="ProdName"></param>
       /// <returns></returns>
        object GetProducts_WithMoreInfo(string Subcategory);
                
        
    }
}
