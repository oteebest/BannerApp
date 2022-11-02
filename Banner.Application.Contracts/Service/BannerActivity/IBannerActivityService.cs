using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Contracts.Service.BannerActivity
{
    public interface IBannerActivityService
    {
        Task<int> AddAsync(BannerActivityInput input);
    }
}
