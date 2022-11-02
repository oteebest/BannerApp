using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Contracts.Service.BannerStats
{
    public class BannerStatDto
    {
        public Guid BannerId { get; set; }
        public string Title{get; set;}
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Impressions { get; set; }
        public int Clicks { get; set; }
    }
}
