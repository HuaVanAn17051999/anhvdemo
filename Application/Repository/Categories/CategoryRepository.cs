using Application.Contract.Criteria.Categoies;
using Application.Contract.Model.Common;
using Application.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Categories
{
    public class CategoryRepository : RespositoryBase<Entities.Categories, ShopDbContext>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext context) : base(context)
        {

        }

        //public Task Delete(int id)
        //{
        //    var listCategory = new List<Entities.Categories>();

        //    var parent = DbSet.Where(x => x.ParentId == id).ToListAsync();
        //}

        public async Task<PageResultData<Entities.Categories>> SearchAsync(CategoriesCriteria criteria)
        {
            var query = DbSet
                 .Where(x =>
                 (
                     string.IsNullOrEmpty(criteria.Name) || x.Name.ToLower().Contains(criteria.Name.ToLower())
                 )
                 //&&
                 //(
                 //   string.IsNullOrEmpty(criteria.DateCreate.ToString())
                 //)
                 )
                 .AsNoTracking();

            int totalRecord = await query.CountAsync();
            criteria.SortColumn = string.IsNullOrEmpty(criteria.SortColumn) ? string.Empty : criteria.SortColumn;
            bool isAsc = criteria.SortDirection.ToLower().Equals("asc");

            switch (criteria.SortColumn)
            {
                case "name":
                    query = isAsc ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
                    break;
                default:
                    query = isAsc ? query.OrderBy(x => x.DateCreate) : query.OrderByDescending(x => x.DateCreate);
                    break;
            }

            var rerutnData = await query.Skip(criteria.CurrentPage * criteria.ItemPerPage).Take(criteria.ItemPerPage).ToListAsync();

            return new PageResultData<Entities.Categories>(totalRecord, rerutnData);
        }
    }
}
