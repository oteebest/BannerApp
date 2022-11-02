using AutoMapper;
using Banner.Application.Contracts.Service.Banner;
using Banner.Application.Contracts.Service.BannerStats;

namespace Banner.Application.Mappings.BannerStats
{
    public class BannerStatsProfile : Profile
    {
        public BannerStatsProfile()
        {
            CreateMap<Domain.Entities.BannerStat, BannerStatDto>();
        }
    }
}
