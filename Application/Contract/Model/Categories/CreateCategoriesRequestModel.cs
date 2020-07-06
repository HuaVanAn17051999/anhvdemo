using Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Contract.Model.Categories
{
    public class CreateCategoriesRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
