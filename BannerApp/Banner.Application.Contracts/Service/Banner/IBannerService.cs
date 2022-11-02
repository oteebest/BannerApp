using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Contracts.Service.Banner
{
    public interface IBannerService
    {
        Task<BannerDto> GetAsync(Guid bannerId);
        Task<BannerDto> GetBannerToDisplayAsync();
        Task ShuffleBannerForDisplayAsync();

    }
}
