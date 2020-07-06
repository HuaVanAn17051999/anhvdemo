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
                typeof(ParentAutoMapperProfile),
                typeof(CategoriesAutoMapperProfile),
                typeof(ProductAutoMapperProfile)
            };
            services.AddAutoMapper(profiles);
            return services;
        }
    }
}
