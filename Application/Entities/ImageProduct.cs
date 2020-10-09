using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class ImageProduct
    {
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public Product Product{ get; set; }
        public Image Image { get; set; }
    }
}
