using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public class Repository<T, TContext> : IRepository<T> where T  : class
        where TContext : DbContext
    {
        private readonly DbSet<T> _dbSet;
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public DbSet<T> DbSet
        {
            get
            {
                return _dbSet;
            }
        }
        public TContext Context
        {
            get
            {
                return _context;
            }
        }
    }
}
