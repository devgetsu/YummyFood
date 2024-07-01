using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Infrastructure.Persistance
{
    public class YummyFoodDbContext : IdentityDbContext<UserApp, IdentityRole<long>, long>, IApplicationDbContext
    {
        public YummyFoodDbContext(DbContextOptions<YummyFoodDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellation)
        {
            return await base.SaveChangesAsync(cancellation);
        }
    }
}
