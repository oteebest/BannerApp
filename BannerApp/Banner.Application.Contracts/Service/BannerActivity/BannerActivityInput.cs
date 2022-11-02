using Banner.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Application.Contracts.Service.BannerActivity
{
    public class BannerActivityInput
    {
        public Guid BannerId { get; set; }
        public Event Event { get; set; }
    }
}
