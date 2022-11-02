using Banner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banner.Application.Contracts.Database
{
    public interface IDatabaseService
    {
        DbSet<Banner.Domain.Entities.Banner> Banners { get; set; }
        DbSet<BannerActivity> BannerActivities { get; set; }
        DbSet<BannerStat> BannerStats { get; set; }
        Task<int> SaveAsync(CancellationToken token = default);
    }
}
