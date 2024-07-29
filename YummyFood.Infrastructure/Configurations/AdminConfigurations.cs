using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Infrastructure.Configurations
{
    public class AdminConfigurations : IEntityTypeConfiguration<AdminApp>
    {
        public void Configure(EntityTypeBuilder<AdminApp> builder)
        {
            builder.HasData(new AdminApp[]
            {
                new AdminApp()
                {
                   Id = 1,
                   UserName = "Super Admin",
                   Password = "Admin01!",
                   PhoneNumber = "990019010",
                   Role = "SuperAdmin",
                }
            });
        }
    }
}
