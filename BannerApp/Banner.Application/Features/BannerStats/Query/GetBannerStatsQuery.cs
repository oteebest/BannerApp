using Banner.Application.Contracts.Service.BannerStats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Features.BannerStats.Query
{
    public class GetBannerStatsQuery : IRequest<List<BannerStatDto>>
    {
        public DateTimeOffset SearchDate { get; set; }
    }

    public class GetBannerStatsQueryHandler : IRequestHandler<GetBannerStatsQuery, List<BannerStatDto>>
    {
        private readonly IBannerStatsService _bannerStatsService;
        public GetBannerStatsQueryHandler(IBannerStatsService bannerStatsService)
        {
            _bannerStatsService = bannerStatsService;
        }
        public async Task<List<BannerStatDto>> Handle(GetBannerStatsQuery request, CancellationToken cancellationToken)
        {
           return await _bannerStatsService.GetBannerStatsAsync(request.SearchDate);
        }
    }
}
