using Application.Contract.Criteria.Categoies;
using Application.Contract.Model.Categories;
using Application.Contract.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Categories
{
    public interface ICategoriesAppService : IAppService<Entities.Categories>
    {
        Task<CategoriesReponseModel> CreateAsync(CreateCategoriesRequestModel createCategoriesRequestModel);
        Task<CategoriesReponseModel> UpdateAsync(int id, UpdateCategoriesRequestModel updateCategoriesRequestModel);
        Task<PageResultData<CategoriesReponseModel>> SearchAsync(CategoriesCriteria criteria);
        Task DeleteAsync(int id);
        Task<List<Category_Custom>> GetListAsync();

        //Task<CategoriesReponseModel> GetListAsync();

    }
}
