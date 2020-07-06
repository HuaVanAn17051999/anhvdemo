using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public int SortOrder { set; get; }
        public int ParentId { set; get; }
        public Status Status { set; get; }
        public string SeoTitle { set; get; }
        public DateTime DateCreate { get; set; }
        public IList<Product> Products { get; set; }
        public Parent Parents { get; set; }
    }
}
