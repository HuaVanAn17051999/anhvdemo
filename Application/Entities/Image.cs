using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ImageSize { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public virtual List<ImageProduct> ImageProducts { get; set; }
    }
}
