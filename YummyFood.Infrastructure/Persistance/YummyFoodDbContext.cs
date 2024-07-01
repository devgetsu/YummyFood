using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Infrastructure.Persistance
{
    public class YummyFoodDbContext : IdentityDbContext<UserApp, IdentityRole<long>, long>
    {
        public YummyFoodDbContext(DbContextOptions<YummyFoodDbContext> options)
            : base(options) 
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
