using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { set; get; }
        public int Stock { get; set; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string Details { set; get; }
        public string SeoTitle { set; get; }
        public Categories Category { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
