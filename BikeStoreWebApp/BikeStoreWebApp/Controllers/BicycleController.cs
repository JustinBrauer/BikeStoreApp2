using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using BikeStoreWebApp.Models;
using BikeStoreWebApp_Database;

namespace BikeStoreWebApp.Controllers
{
    public class BicycleController : Controller
    {
        // GET: Bicycle
        [Route]
        public ActionResult Store()
        {
            var category = new List<StoreHome>
            {
                new StoreHome { categoryID = 1, categoryName = "Mountain Bicycles", categoryImage = "~/Images/patriotmountain.jpg" },
                new StoreHome { categoryID = 2, categoryName = "Road Bicycles", categoryImage = "~/Images/cinelliroad.jpg" },
                new StoreHome { categoryID = 3, categoryName = "Touring Bicycles", categoryImage = "~/Images/cannontouring.jpg"}
            };

            return View(category);
        }

        [Route("{id:int}")]
        public ActionResult Listing(int id)
        {
            BikeStoreWebApp.Models.BicycleListing bicycle = new BikeStoreWebApp.Models.BicycleListing();

            var listing = new List<spGetProductsbySubcategoryID_Result>();

            var item = bicycle.GetBicyclesForListing(id);

            foreach (spGetProductsbySubcategoryID_Result product in item)
            { 
                listing.Add(product);
            }

            return View(listing);
        }

        [Route("{id:int}")]
        public ActionResult Description(int id)
        {
            BikeStoreWebApp.Models.BicycleDescription bicycle = new BikeStoreWebApp.Models.BicycleDescription();

            var description = new List<spGetProductDetails_Result>();
            var item = bicycle.GetBicycleDetailForDescription(id);
            foreach (spGetProductDetails_Result product in item)
            {
                description.Add(product);
            }

            return View(description);
        }

        [Route]
        public ActionResult Cart()
        {
            return View();
        }

        [Route]
        public ActionResult Checkout()
        {
            return View();
        }

        [Route]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}