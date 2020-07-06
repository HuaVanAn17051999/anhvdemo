using Application.Contract.Model.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Settings.Common
{
    public static class CommonConfiguration
    {
        public static IServiceCollection InjectCommon(this IServiceCollection services,  IConfiguration configuration)
        {
            services.Configure<JwTOption>(options =>
            {
                var jwtSection = configuration.GetSection("JWT").Get<JwTSettingModel>();
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.SecrectKey));

                options.Audience = jwtSection.UrlSite;
                options.Issuer = jwtSection.UrlSite;
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });
            services.AddScoped<JwTOption>(c => c.GetService<IOptions<JwTOption>>().Value);
            return services;
        }
    }
}
