using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Criteria.Categoies
{
    public class CategoriesCriteria : BaseCriteria
    {
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
