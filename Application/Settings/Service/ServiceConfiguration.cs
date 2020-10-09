
using Application.Common;
using Application.Services.Categories;
using Application.Services.Order;
using Application.Services.Product;
using Application.Services.Roles;
using Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Application.Settings.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection InjectService(this IServiceCollection services)
        {
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddTransient<IStorageService, FileStorageService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ICategoriesAppService, CategoriesAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IRoleService, RoleService>();
         
            
            return services;
        }
    }
}
