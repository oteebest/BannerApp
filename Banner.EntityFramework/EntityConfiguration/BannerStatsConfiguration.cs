using Banner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Banner.EntityFramework.EntityConfiguration
{
    public class BannerStatsConfiguration : IEntityTypeConfiguration<BannerStat>
    {
        public void Configure(EntityTypeBuilder<BannerStat> builder)
        {
            builder.ToTable("ViewNameInDatabase", t => t.ExcludeFromMigrations());
        }
    }
}
