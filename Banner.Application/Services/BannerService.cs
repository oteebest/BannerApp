using AutoMapper;
using Banner.Application.Contracts.Database;
using Banner.Application.Contracts.Service.Banner;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Services
{
    public class BannerService: IBannerService
    {
        private readonly IDatabaseService _dbService;
        private readonly IMapper _mapper;

        public BannerService(IDatabaseService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public async Task<BannerDto> GetAsync(Guid bannerId)
        {
            var banner = await _dbService.Banners.FirstAsync(u => u.Id == bannerId);

            return _mapper.Map<BannerDto>(banner);
        }

        public async Task<BannerDto> GetBannerToDisplayAsync()
        {
            var banner = await _dbService.Banners.FirstOrDefaultAsync(u => u.Online);

            return _mapper.Map<BannerDto>(banner);
        }

        public async Task ShuffleBannerForDisplayAsync()
        {
            var banner = await _dbService.Banners.FirstOrDefaultAsync(u => u.Online);

            if (banner != null)
            {
                banner.Online = false;

                _dbService.Banners.Update(banner);
                await _dbService.SaveAsync();
            }

           var count =  _dbService.Banners.Count();

            Random rnd = new Random();
            int nextBannerToDisplayIndex = rnd.Next(0, count);

            var nextBannerToDisplay = _dbService.Banners.Skip(nextBannerToDisplayIndex).Take(1).First();

            nextBannerToDisplay.Online = true;

            await _dbService.SaveAsync();
        }
    }
}
