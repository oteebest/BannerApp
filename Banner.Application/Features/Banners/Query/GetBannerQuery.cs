using Banner.Application.Contracts.Service.Banner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Runtime.CompilerServices;
using Banner.Application.Contracts.Service.BannerActivity;
using Banner.Application.Services;
using Banner.Domain.Shared.Enums;

namespace Banner.Application.Features.Banners.Query
{
    public class GetBannerQuery : IRequest<BannerDto>
    {

    }

    public class GetBannerQueryHander : IRequestHandler<GetBannerQuery, BannerDto>
    {
        private readonly IBannerService _bannerService;
        private readonly IBannerActivityService _bannerActivityService;

        public GetBannerQueryHander(IBannerService bannerService, IBannerActivityService bannerActivityService)
        {
            _bannerService = bannerService;
            _bannerActivityService = bannerActivityService;
        }

        public async Task<BannerDto> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var banner = await _bannerService.GetBannerToDisplayAsync();
            await _bannerActivityService.AddAsync(new BannerActivityInput { BannerId = banner.Id, Event = Event.Display });
            await _bannerService.ShuffleBannerForDisplayAsync();

            return banner;
        }
    }
}
