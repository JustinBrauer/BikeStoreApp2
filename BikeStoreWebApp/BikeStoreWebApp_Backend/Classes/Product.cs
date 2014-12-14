using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.Sql;
using BikeStoreWebApp;
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp_Backend.Classes 
{
    public class Product : IProduct
    {
         string _prodName;
        public string prodName
        {
            get { return this._prodName; }
            set { this._prodName = value; }
        }

        private int _prodNum;
        public int prodNum
        {
            get { return this._prodNum; }
            set { this._prodNum = value; }
        }

        private decimal _prodPrice;
        public decimal prodPrice
        {
            get { return this._prodPrice; }
            set { this._prodPrice = value; }
        }


        /// <summary>
        /// Implementation Method:
        /// -This will grab all bikes in particular SubCategory
        /// </summary>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        public IList<spGetBikesBySubCategory_Result> GetBikes_WithLessInfo(string SubCategory)
        {
            using (ist440grp1Entities1 entities = new ist440grp1Entities1())
            {
                var bikes = entities.spGetBikesBySubCategory(SubCategory);

                return bikes.ToList();
            }
        }

        /// <summary>
        /// Implementation Method:
        /// -This will help you find out what the subcategory is for a particular Product
        /// -ProdId is a optional parameter. It will send in a 0 if not specified.
        /// -This will Return a subcategory Name of the single product that was specified.
        /// </summary>
        /// <param name="prodName"></param>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public string DetermineSubCategoryPerItem(string prodName, int prodId = 0)
        {
            try
            {
                using (ist440grp1Entities1 entities = new ist440grp1Entities1())
                {
                    string subcategory;
                    if (prodNum != 0)
                    {
                        subcategory = (from p in entities.Products
                                       join s in entities.ProductSubcategories on p.ProductSubcategoryID equals s.ProductSubcategoryID
                                       where p.Name == prodName
                                       select s.Name).Single();
                        
                    }
                    else
                    {
                        subcategory = (from p in entities.Products
                                       join s in entities.ProductSubcategories on p.ProductSubcategoryID equals s.ProductSubcategoryID
                                       where p.ProductID == prodId
                                       select s.Name).Single();
                    }
                    return subcategory;
                }
            }
            catch (NullReferenceException nre)
            {
                return "Please use a Different Name or Id. the Name/Id: \"" + prodName + "/" + prodId + "\" does ot exist in the database";
                //Log this in the Log File (Not implented Yet)                
            }
            catch (Exception ex)
            {
                return "Contact admin of Website";
                //Log this in the Log File (Not implented Yet)
            }
            
        }

        /// <summary>
        /// Implementation Method:
        /// -This will Return a Price that is stored in the DB for a particular product. 
        /// </summary>
        /// <returns></returns>
        public object GetProducts_WithMoreInfo(string Subcategory)
        {
            return null;       
        }

        /// <summary>
        /// Implementation Method:
        /// -Using either the Product Name or the product id(This is optional)
        /// -You will be able to used a SPROC to Capture the quantity of a single Product.
        /// -Also maybe able to use linq to do the same thing.
        /// -This will return the amount of a single product within the DB.
        /// </summary>
        /// <param name="prodName"></param>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public int DetermineStockPerItem(string prodName, int prodId = 0)
        {
            return 0;
        }

        /// <summary>
        /// Implentation Method:
        /// -This method will update the DB with the correct amount for each product that has been ordered.
        /// -
        /// </summary>
        /// <param name="produQuantity"></param>
        /// <param name="prodName"></param>
        /// <param name="prodId"></param>
        public void AfterOrderComplete_DeductQuantity(string produQuantity, string prodName, int prodId = 0)
        {

        }
        
        /// <summary>
        /// Implentation Method:
        /// -GetOneProduct => Searches for a produt by its Id.
        /// -Returns a list of product types.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BikeStoreWebApp_Database.Product> GetOneProduct(int id)
        {
            ist440grp1Entities1 db = new ist440grp1Entities1();

            var product = from p in db.Products
                          where p.ProductID == id
                          select p;

            return product.ToList();
        }  
     
        public decimal CalculateProductTotal(decimal listPrice, decimal percentageOff, decimal taxpercent)
        {
            decimal total;

            total = (listPrice - (listPrice * percentageOff)) + (listPrice * taxpercent);

            return total;
        }
    }
}