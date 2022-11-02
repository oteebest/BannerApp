using Banner.Application.Contracts.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Database
{
    public class DatabaseSeeder: IDatabaseSeeder
    {
        private readonly IDatabaseService _dbService;
        public DatabaseSeeder(IDatabaseService dbService)
        {
            _dbService = dbService;
        }
        public void Initialise()
        {
           
                if(!_dbService.Banners.Any(u => u.Title == "Banner 1"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 1", ImageUrl = "https://localhost:7184/images/banner/banner1.jpg", LinkUrl = "https://www.google.com", Online = true });
                }

                if (!_dbService.Banners.Any(u => u.Title == "Banner 2"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 2", ImageUrl = "https://localhost:7184/images/banner/banner2.jpg", LinkUrl = "https://web.facebook.com", Online = false });

                }

                if (!_dbService.Banners.Any(u => u.Title == "Banner 3"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 3", ImageUrl = "https://localhost:7184/images/banner/banner3.jpg", LinkUrl = "https://www.amazon.com", Online = false });

                }

                if (!_dbService.Banners.Any(u => u.Title == "Banner 4"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 4", ImageUrl = "https://localhost:7184/images/banner/banner4.jpg", LinkUrl = "https://www.airbnb.com", Online = false });
                }

                if (!_dbService.Banners.Any(u => u.Title == "Banner 5"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 5", ImageUrl = "https://localhost:7184/images/banner/banner5.jpg", LinkUrl = "https://www.booking.com", Online = false });
                }

                if (!_dbService.Banners.Any(u => u.Title == "Banner 6"))
                {
                    _dbService.Banners.Add(new Domain.Entities.Banner { Title = "Banner 6", ImageUrl = "https://localhost:7184/images/banner/banner6.jpg", LinkUrl = "https://www.yahoo.com", Online = false });
                }

                _dbService.SaveAsync();

        }
    }
}
