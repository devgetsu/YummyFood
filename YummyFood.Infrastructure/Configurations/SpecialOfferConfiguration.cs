using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Infrastructure.Configurations
{
    public class SpecialOfferConfiguration : IEntityTypeConfiguration<SpecialOffer>
    {
        public void Configure(EntityTypeBuilder<SpecialOffer> builder)
        {
            builder.Property(x => x.Subtitle)
                .IsRequired().HasMaxLength(30);


            builder.Property(x => x.Title)
                .IsRequired().HasMaxLength(30);
        }
    }
}
