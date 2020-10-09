using Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
          

            //modelBuilder.Entity<Categories>().HasData(
            //    new Categories { Id = 1, ParentId = 1, Name = "IPHONE" },
            //    new Categories { Id = 2, ParentId = 1, Name = "SAMSUMG" },
            //    new Categories { Id = 3, ParentId = 1, Name = "XIAOMI" },
            //    new Categories { Id = 4, ParentId = 2, Name = "DELL" },
            //    new Categories { Id = 5, ParentId = 2, Name = "ASUS" }
            //    );

            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, CategoryId = 1, Name = "IPHONE 11 PRO", Price = 15000000, OriginalPrice = 12000000, Stock = 10},
            //    new Product { Id = 2, CategoryId = 1, Name = "IPHONE XS PRO", Price = 22000000, OriginalPrice = 17000000, Stock = 8 },
            //    new Product { Id = 3, CategoryId = 1, Name = "IPHONE XMAX PRO", Price = 16000000, OriginalPrice = 32000000, Stock = 70 },
            //    new Product { Id = 4, CategoryId = 1, Name = "IPHONE 11 PRO", Price = 20000000, OriginalPrice = 19000000, Stock = 10 },
            //    new Product { Id = 5, CategoryId = 2, Name = "SAMSUMG 11 PRO", Price = 15000000, OriginalPrice = 12000000, Stock = 10 },
            //    new Product { Id = 6, CategoryId = 2, Name = "SAMSUMG 12 PRO", Price = 15000000, OriginalPrice = 12000000, Stock = 10 }
            //    );


        }
    }
}
