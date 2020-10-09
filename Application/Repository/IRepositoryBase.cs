using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IRepositoryBase<T> : IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity, bool isSaved = false);
        Task<T> UpdateAsync(T entity, bool isSaved = false);
        Task DeleteAsync(int id);
        Task<List<T>> GetListAsync();
    }
}
