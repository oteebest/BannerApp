using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BannerApp.Controllers.Base
{
    public class BaseController : Controller
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
