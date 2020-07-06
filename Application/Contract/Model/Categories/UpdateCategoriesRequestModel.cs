using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Categories
{
    public class UpdateCategoriesRequestModel
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Status Status { get; set; }
    }
}
