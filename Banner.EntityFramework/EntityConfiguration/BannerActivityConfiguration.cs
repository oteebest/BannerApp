using Banner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.EntityFramework.EntityConfiguration
{
    public class BannerActivityConfiguration : IEntityTypeConfiguration<BannerActivity>
    {
        public void Configure(EntityTypeBuilder<BannerActivity> builder)
        {
            builder.HasOne(u => u.Banner).WithMany(u => u.BannerActivities); 
        }
    }
}
