using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.ObjectModel;
using System.Data.Entity;
//using System.Data.Query;    //Commented out because there was a missing namespace error
using BikeStoreWebApp_Backend.Interfaces;
using BikeStoreWebApp_Backend.Classes;
using BikeStoreWebApp_Database;
using BikeStoreWebApp;
using System.Web;
using System.Web.Mvc;

namespace BikeStoreWebApp_UnitTestProject
{
    /// <summary>
    /// Summary description for Produc_UnitTests
    /// </summary>
    [TestClass]
    public class Product_UnitTests
    {
        BikeStoreWebApp.Controllers.BicycleController bikelistpage = new BikeStoreWebApp.Controllers.BicycleController();

        BikeStoreWebApp_Backend.Classes.Product _product = new BikeStoreWebApp_Backend.Classes.Product();
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_BikesAreReturnedfrom_GetBikeBySubCategory()
        {
            
            var Bikes = _product.GetBikes_WithLessInfo("Touring");

            Assert.IsInstanceOfType(Bikes, typeof(spGetBikesBySubCategory_Result));          
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_BikesAreNotReturned_InvalidSubCategory()
        {
            var Bikes = _product.GetBikes_WithLessInfo("Tours");

            Assert.IsInstanceOfType(Bikes, typeof(spGetBikesBySubCategory_Result));  
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CalculateProductTotal_Valid()
        {
            decimal listPrice = 60.00m; 
            decimal percentageOff = 0.30m;
            decimal taxPercentage = 0.06m;
            decimal total;

            total = Math.Round(_product.CalculateProductTotal(listPrice, percentageOff, taxPercentage), 2);

            Assert.AreEqual(45.60m, total);           
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CalculateProductTotal_Invalid()
        {
            decimal listPrice = 60.00m;
            decimal percentageOff = 0.30m;
            decimal taxPercentage = 0.06m;
            decimal total;

            total = Math.Round(_product.CalculateProductTotal(listPrice, percentageOff, taxPercentage), 2);

            Assert.AreNotEqual(40.00m, total);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void tst_CalculateProductTotal_TypeOf()
        {
            decimal listPrice = 60.00m;
            decimal percentageOff = 0.30m;
            decimal taxPercentage = 0.06m;;

            var total = Math.Round(_product.CalculateProductTotal(listPrice, percentageOff, taxPercentage), 2);

            Assert.IsInstanceOfType(total, typeof(decimal));
        }
        /// <summary>
        /// For BikeListing page + BicycleController
        /// </summary>
        [TestMethod]
        public void tst_GetProductsBySubCategoryID_Valid()
        {
            //arranged
            int id = 1;
            //BikeStoreWebApp.Controllers.BicycleController control = new BikeStoreWebApp.Controllers.BicycleController();
            BikeStoreWebApp.Models.BicycleListing list = new BikeStoreWebApp.Models.BicycleListing();
            
            //act
            var mountain = list.GetBicyclesForListing(id);

            //assert
            Assert.IsNotNull(mountain);
        }
    }
}
