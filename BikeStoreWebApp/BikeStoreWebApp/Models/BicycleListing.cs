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
    public class BicycleListing: spGetProductsbySubcategoryID_Result
    {
        //public int id { get; set; }
        //public string name { get; set; }
        //public double price { get; set; }
        //public string image { get; set; }
        //public string description { get; set; }
        //public byte[] ImageBytes;
        //public Image localImage;

        //string mtnImageFilePath = "~/Images/bicycles/mtn/";
        //string roadImageFilePath = "~/Images/bicycles/road/";
        //string tourImageFilePath = "~/Images/bicycles/mtn/";

        //string[] mtnImageName = { "mtn-diamondback.jpg", "mtn-granite-peak.jpg", "mtn-gravity.jpg", 
        //                        "mtn-huffy.jpg", "mtn-jeep.jpg", "mtn-kawasaki.jpg",
        //                        "mtn-mongoose.jpg", "mtn-northwoods.jpg", "mtn-pacific.jpg"};

        //string[] roadImageName = { "road-denali.jpg", "road-diamondback.jpg", "road-framed-elite.jpg", 
        //                        "road-genesis-roadtech.jpg", "road-giordano.jpg", "road-head-accel.jpg",
        //                        "road-kestrel-talon.jpg", "road-mercier-elle.jpg", "road-nashbar.jpg"};

        //string[] tourImageName = { "tour-co-motion.jpg", "tour-jamis-aurora.jpg", "tour-lynskey-viale.jpg", 
        //                        "tour-nashbar-tr1.jpg", "tour-novara-randonee.jpg", "tour-seven-cycle-expat.jpg",
        //                        "tour-space-horse.jpg", "tour-trek-520.jpg", "tour-weekender.jpg"};

        protected BikeStoreWebApp_Database.ist440grp1Entities1 db;

        public List<spGetProductsbySubcategoryID_Result> GetBicyclesForListing(int cat)
        {
            
            //var conn = ConfigurationManager.ConnectionStrings["ist440grp1Entities1"].ConnectionString;
            using (db = new ist440grp1Entities1())
            {
                var sql = "exec spGetProductsbySubcategoryID @subCategoryID";
                var idParam = new SqlParameter("subCategoryID", cat);
                var query = db.Database.SqlQuery<spGetProductsbySubcategoryID_Result>(sql, idParam);
                var listing = query.ToList();

                //foreach (spGetProductsbySubcategoryID_Result item in listing)
                //{
                //    listing.Insert()
                //}

                foreach (spGetProductsbySubcategoryID_Result item in listing)
                {
                    ByteArrayToImage(item.ThumbNailPhoto);
                }

                //if (cat == 1)
                //{
                //    foreach (spGetProductsbySubcategoryID_Result item in listing)
                //    {
                //        string newImagePath = mtnImageFilePath + mtnImageName[0];
                //    }
                //}
                //else if (cat == 2)
                //{
                //    foreach (spGetProductsbySubcategoryID_Result item in listing)
                //    {
                //        string newImagePath = roadImageFilePath + roadImageName[0];
                //    }
                //}
                //else if (cat == 3)
                //{
                //    foreach (spGetProductsbySubcategoryID_Result item in listing)
                //    {
                //        string newImagePath = tourImageFilePath + tourImageName[0];
                //    }
                //}

                return listing;
            }
        }

        public void SaveImgToFile(byte[] imageBytes, string fileName)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                image.Save(fileName);
                //image.Save(@"testShipImg.GIF");
            }
            catch (Exception ex)
            {
                string strExc = ex.ToString();
                Console.WriteLine("strExc");
            }
        }

        public void ByteArrayToImage(byte[] img)
        {
            try
            {
                MemoryStream ms = new MemoryStream(img, 0, img.Length);
                var image = Image.FromStream(ms);
            }
            catch (Exception ex)
            { }
        }

        //public List<spGetProductsbySubcategoryID_Result> GetBicycles(int catID)
        //{
        //    using (BikeStoreWebApp_Database.ist440grp1Entities1 db = new BikeStoreWebApp_Database.ist440grp1Entities1())
        //    {
        //        var listing = db.spGetProductsbySubcategoryID(catID);
        //        listing.Take(9);

        //        //var bikes = db.spGetProductsbySubcategoryID_Result(catID);

        //        return listing.ToList();
        //    }
        //}
    }
}