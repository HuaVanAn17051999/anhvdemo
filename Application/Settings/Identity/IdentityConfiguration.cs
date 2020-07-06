using Application.Contract.Model.Common;
using Application.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application.Settings.Identity
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentity<TUser , TRole, TDbContext>(this IServiceCollection services)
        where TUser : class
        where TRole : class
        where TDbContext : DbContext
        {
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            return services;
        }
        public static IServiceCollection AddAuthJWToken(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("JWT").Get<JwTSettingModel>();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.SecrectKey));

            services
           .AddAuthentication(options =>
           {
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = signingKey,
                   ValidIssuer = jwtSection.UrlSite,
                   ValidAudience = jwtSection.UrlSite,
                   ValidateLifetime = true,
               };
           });
            return services;
        }
        public static IApplicationBuilder UseAuthJWTToken(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JwTMiddleware>();
            return builder;
        }
    }
}
