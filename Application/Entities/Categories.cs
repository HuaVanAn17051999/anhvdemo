using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { set; get; }
        public string SeoTitle { set; get; }
        public int ParentId { get; set; }
        public DateTime DateCreate { get; set; }
        public IList<Product> Products { get; set; }
    }
}
