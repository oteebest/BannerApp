using Banner.Application.Contracts.Database;
using Banner.Application.Contracts.Service.BannerActivity;
using Banner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Services
{
    public class BannerActivityService : IBannerActivityService
    {
        private readonly IDatabaseService _dbService;

        public BannerActivityService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> AddAsync(BannerActivityInput input)
        {
            _dbService.BannerActivities.Add(new BannerActivity { BannerId = input.BannerId, Event = input.Event  });

            return await _dbService.SaveAsync();
        }
    }
}
