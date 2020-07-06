
using Application.Services.Parent;
using Application.Services.User;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Settings.Service
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection InjectService(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IParentAppService, ParentAppService>();
            return services;
        }
    }
}
