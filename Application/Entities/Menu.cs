using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public IList<TypeMenu> TypeMenus { get; set; }
    }
}
