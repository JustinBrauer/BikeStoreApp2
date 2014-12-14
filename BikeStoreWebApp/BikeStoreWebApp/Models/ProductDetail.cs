using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStoreWebApp.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProdNumber { get; set; }
        public string color { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; }
        
        
    }
}