using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Error404_TLT.Models.ViewsModel
{
    public class ProductOfCartModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public Nullable<int> ProductAmount { get; set; }
    }
}