using Banner.Application.Contracts.Database;
using Banner.Application.Contracts.Service.Banner;
using Banner.Application.Contracts.Service.BannerActivity;
using Banner.Application.Contracts.Service.BannerStats;
using Banner.Application.Database;
using Banner.Application.Services;
using Banner.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BannerApp.Extentions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BannerDatabase");
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Banner.EntityFramework")))
                 .AddTransient<IDatabaseSeeder, DatabaseSeeder>(); ;

            serviceCollection.AddScoped<IDatabaseService, ApplicationDbContext>();

            return serviceCollection;
        }

        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBannerService, BannerService>();
            serviceCollection.AddScoped<IBannerActivityService, BannerActivityService>();
            serviceCollection.AddScoped<IBannerStatsService, BannerStatsService>();
        }
    }
}
