using Application.Contract.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Settings.Database
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services,  IConfiguration configuration)
        {
            ConnectionStringModel model = configuration.GetSection("ConnectionStrings").Get<ConnectionStringModel>();
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(model?.DefaultConnection);
            });
            return services;
        }
    }
}
