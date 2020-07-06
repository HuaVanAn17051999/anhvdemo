using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Common
{
    public class PageResultData<T> where T : class
    {
        public int TotalRecords { get; set; }
        public IList<T> Data { get; set; }
        public PageResultData(int totalRecords, IList<T> data)
        {
            this.Data = data;
            this.TotalRecords = totalRecords;
        }
    }
}
