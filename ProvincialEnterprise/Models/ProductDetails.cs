using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models
{
    public class ProductDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }

    }
}