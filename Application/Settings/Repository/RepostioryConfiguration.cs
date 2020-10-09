
using Application.Repository.Categories;
using Application.Repository.Order;
using Application.Repository.Products;
using Application.Repository.Roles;
using Application.Repository.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Settings.Repository
{
    public static class RepostioryConfiguration
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddTransient<DbContext, ShopDbContext>();
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepostiory>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
       
            return services;
        }
    }
}
