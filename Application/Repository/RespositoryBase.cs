using Application.Contract.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RespositoryBase<T, TContext> : Repository<T, TContext>, IRepositoryBase<T> where T : class
        where TContext : DbContext
    {
        public RespositoryBase(TContext context) : base(context)
        {

        }
        public async Task<T> CreateAsync(T entity , bool isSaved = false)
        {
            await Context.AddAsync<T>(entity);
            if (isSaved)
            {
                await Context.SaveChangesAsync(); 
            }
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(id));
            }
            Context.Remove<T>(entity);
            await Context.SaveChangesAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<List<T>> GetListAsync()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<T> UpdateAsync(T entity, bool isSaved = false)
        {
            Context.Update<T>(entity);
            if (isSaved)
            {
                await Context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
