using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Cart
    {
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
    }
}
