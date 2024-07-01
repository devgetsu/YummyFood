using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Shop> Shops { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<CommentModel> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Address> Addresses { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellation = default!);
    }
}
