using Banner.Application.Contracts.Service.Banner;
using Banner.Application.Features.Banners.Command;
using Banner.Application.Features.Banners.Query;
using BannerApp.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace BannerApp.Controllers
{    
    public class BannerController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var banner = await _mediator.Send(new GetBannerQuery());

            return View(banner);
        }

        [Route("Banner/Click/{id}")]
        public async Task<IActionResult> Click(Guid id)
        {
            var banner = await _mediator.Send(new BannerClickCommand {  BannerId = id});

            return Ok(banner);
        }
    }
}
