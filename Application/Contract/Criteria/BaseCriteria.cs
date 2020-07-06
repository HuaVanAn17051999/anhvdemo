using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Application.Contract.Criteria
{
    public class BaseCriteria
    {
        [DefaultValue(0)]
        public int CurrentPage { get; set; }
        [DefaultValue(20)]
        public int ItemPerPage { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string SearchText { get; set; }
    }
}
