using Banner.Application.Contracts.Service.Banner;
using Banner.Application.Contracts.Service.BannerActivity;
using Banner.Domain.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Features.Banners.Command
{
    public class BannerClickCommand : IRequest<BannerDto>
    {
        public Guid BannerId { get; set; }
    }

    public class BannerClickCommandHandler : IRequestHandler<BannerClickCommand, BannerDto>
    {
        private readonly IBannerActivityService _bannerActivityService;
        private readonly IBannerService _bannerService;
        public BannerClickCommandHandler(IBannerActivityService bannerActivityService, IBannerService bannerService)
        {
            _bannerActivityService = bannerActivityService;
            _bannerService = bannerService;
        }
        public async Task<BannerDto> Handle(BannerClickCommand request, CancellationToken cancellationToken)
        {
            await _bannerActivityService.AddAsync(new BannerActivityInput { BannerId = request.BannerId, Event = Event.Clicked });

            return await _bannerService.GetAsync(request.BannerId);
        }
    }
}
