using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banner.Domain.Entities
{
    [Keyless]
    public class BannerStat
    {
        public Guid BannerId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Impressions { get; set; }
        public int Clicks { get; set; }

    }
}
