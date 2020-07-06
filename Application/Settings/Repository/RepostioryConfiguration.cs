using Application.Repository.Parents;
using Application.Repository.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Settings.Repository
{
    public static class RepostioryConfiguration
    {
        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddTransient<DbContext, ShopDbContext>();
            services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
