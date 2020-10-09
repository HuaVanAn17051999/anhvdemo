using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Categories
{
    public class UpdateCategoriesRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int ParentId { get; set; }
    }
}
