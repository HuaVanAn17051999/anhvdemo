using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Contract.Model.Products
{
    public class CreateProductRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price{ get; set; }
        [Required]
        public decimal OldPrice{ get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
