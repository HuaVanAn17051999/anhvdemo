using Application.Contract.Criteria.Categoies;
using Application.Contract.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Categories
{
    public interface ICategoryRepository : IRepositoryBase<Entities.Categories>
    {
        Task<PageResultData<Entities.Categories>> SearchAsync(CategoriesCriteria criteria);
        //Task Delete(int id);
    }
}
