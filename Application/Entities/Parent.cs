using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Parent : BaseEntity
    {
        public string Name { get; set; }
        public string SeoTitle { get; set; }
        public IList<Categories> Categories { get; set; }
    }
}
