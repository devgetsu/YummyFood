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
    public class PromoConfiguration : IEntityTypeConfiguration<Promo>
    {
        public void Configure(EntityTypeBuilder<Promo> builder)
        {
            builder.Property(x => x.Code)
                .HasMaxLength(10);
        }
    }
}
