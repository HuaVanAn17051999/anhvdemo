using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> DbSet { get; }
    }
}
