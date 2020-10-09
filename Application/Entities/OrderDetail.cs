using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        //public DateTime DateCreate { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
