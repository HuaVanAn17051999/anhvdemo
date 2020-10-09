
using Application.Common;
using Application.Contract.Model.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Product
{
    public interface IProductAppService : IAppService<Entities.Product>
    {
        //Task<ProductReponseModel> CreateAsync(CreateProductRequestModel createProductRequestModel);
        //Task<ProductReponseModel> UpdateAsync(int id, UpdateProductRequestModel updateProductRequestModel);
        Task DeleteAsync(int id);
        Task<PagedList<Entities.Product>>ListProductByCategoryId (int id, OwnerParameters ownerParameters );
        Task<ProductReponseModel> GetByIdAsync(int id);

        
    }
}
