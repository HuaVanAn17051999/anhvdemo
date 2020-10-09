using Application.Common;
using Application.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.Products
{
    public class ProductRepostiory : RespositoryBase<Entities.Product, ShopDbContext>, IProductRepository
    {
        public ProductRepostiory(ShopDbContext context) : base(context)
        {

        }
        public Task<Product> LatestProduct()
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedList<Product>> ListProductByCategoryId(int id, OwnerParameters ownerParameters)
        {
            var source = DbSet.Where(x => x.CategoryId == id).AsNoTracking();

            return await PagedList<Entities.Product>.ToPagedList(source, ownerParameters.PageNumber, ownerParameters.PageSize);
        }
    }
}
