using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.ProductImage
{
    public class ProductImageRequestModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
