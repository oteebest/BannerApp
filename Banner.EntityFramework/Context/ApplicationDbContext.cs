using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banner.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Banner.EntityFramework.EntityConfiguration;
using Banner.Application.Contracts.Database;

namespace Banner.EntityFramework.Context
{
    public class ApplicationDbContext: DbContext, IDatabaseService
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BannerActivity> BannerActivities { get; set; }
        public DbSet<Banner.Domain.Entities.Banner> Banners { get; set; }

        public DbSet<BannerStat> BannerStats { get; set; }

        public Task<int> SaveAsync(CancellationToken token = default )
        {
            return SaveChangesAsync(token);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BannerConfiguration());
            modelBuilder.ApplyConfiguration(new BannerActivityConfiguration());
            modelBuilder.ApplyConfiguration(new BannerStatsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
