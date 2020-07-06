using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Products
{
    public class UpdateProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
