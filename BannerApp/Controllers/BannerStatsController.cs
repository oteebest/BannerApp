using Banner.Application.Contracts.Service.Banner;
using Banner.Application.Features.Banners.Query;
using Banner.Application.Features.BannerStats.Query;
using BannerApp.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace BannerApp.Controllers
{
    public class BannerStatsController : BaseController
    {

        public async Task<IActionResult> Index()
        {
            var bannerStats = await _mediator.Send(new GetBannerStatsQuery { SearchDate = DateTimeOffset.Now });

            return View(bannerStats);
        }
    }
}
