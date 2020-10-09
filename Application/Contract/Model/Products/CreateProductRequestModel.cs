using Application.Contract.Model.ProductImage;
using Microsoft.AspNetCore.Http;
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
        [Display(Name = "Upload Product Image")]
        public IFormFile ImagePath { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
