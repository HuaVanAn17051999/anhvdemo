using System;
using Application.Contract.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Settings.Mapping
{
    public static class ProfileConfiguration
    {
        public static IServiceCollection AddAutoMapperProfileSettings(this IServiceCollection services)
        {
            Type[] profiles = {
               
                typeof(UserAutoMapperProfile),
                typeof(CategoriesAutoMapperProfile),
                typeof(ProductAutoMapperProfile),
                typeof(OrderAutoMapperProfile),
                typeof(RoleAutoMapperProfile)
            };
            services.AddAutoMapper(profiles);
            return services;
        }
    }
}
