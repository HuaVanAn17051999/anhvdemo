using Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Categories
{
    public class CategoriesReponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Seotitle { get; set; }
        public DateTime DateCreate { get; set; }
        public int ParentId { get; set; }
        //public int ParentId { get; set; }
    }
}
