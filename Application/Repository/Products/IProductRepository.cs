using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Products
{
    public interface IProductRepository : IRepositoryBase<Entities.Product>
    {
        Task<PagedList<Entities.Product>> ListProductByCategoryId(int id, OwnerParameters ownerParameters);
        Task<Entities.Product> LatestProduct();
        

    }
}
