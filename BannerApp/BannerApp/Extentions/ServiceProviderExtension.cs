using Banner.Application.Contracts.Database;
using Banner.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BannerApp.Extentions
{
    public static class ServiceProviderExtensions
    {
        public static void MigrateDBSeedData(this ServiceProvider serviceProvider, IConfiguration configuration)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            db.Database.Migrate();

            var dbSeeder = serviceProvider.GetService<IDatabaseSeeder>();
            dbSeeder.Initialise();
        }
    }
    
}
