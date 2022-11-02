using AutoMapper;
using Banner.Application.Contracts.Service.Banner;

namespace Banner.Application.Mappings.Banners
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Domain.Entities.Banner, BannerDto>();
        }
    }
}
