using AutoMapper;
using Banner.Application.Contracts.Database;
using Banner.Application.Contracts.Service.BannerStats;
using Banner.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Services
{
    public class BannerStatsService : IBannerStatsService
    {
        private readonly IDatabaseService _dbService;
        private readonly IMapper _mapper;
        public BannerStatsService(IDatabaseService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }
        public async Task<List<BannerStatDto>> GetBannerStatsAsync(DateTimeOffset searchDate)
        {
            var date = new SqlParameter("@date", SqlDbType.DateTimeOffset);

            date.Value = searchDate;

            var bannerStats =  await _dbService.BannerStats.FromSqlRaw($"Exec Getsummary @date",date).ToListAsync();

            return _mapper.Map<List<BannerStatDto>>(bannerStats);
        }
    }
}
