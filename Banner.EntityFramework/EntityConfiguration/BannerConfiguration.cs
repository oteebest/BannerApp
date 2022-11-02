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
    public class BannerConfiguration : IEntityTypeConfiguration<Banner.Domain.Entities.Banner>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Banner> builder)
        {
            builder.Property(u => u.Title).IsRequired().HasMaxLength(200);
            builder.Property(u => u.ImageUrl).IsRequired().HasMaxLength(500);
            builder.Property(u => u.LinkUrl).IsRequired().HasMaxLength(500);
        }
    }
}
