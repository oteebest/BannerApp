using Banner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Contracts.Service.BannerStats
{
    public interface IBannerStatsService
    {
        Task<List<BannerStatDto>> GetBannerStatsAsync(DateTimeOffset date);
    }
}
