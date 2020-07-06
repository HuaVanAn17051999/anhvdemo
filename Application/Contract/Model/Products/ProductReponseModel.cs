using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Products
{
    public class ProductReponseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { set; get; }
        public int Stock { get; set; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string Details { set; get; } 
        public string SeoTitle { set; get; }
    }
}
