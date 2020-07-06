using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class TypeMenu : BaseEntity
    {
        public string Name { get; set; }
        public Menu Menu { get; set; }
    }
}
