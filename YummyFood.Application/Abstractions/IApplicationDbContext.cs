using Microsoft.EntityFrameworkCore;
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
        DbSet<Card> Cards { get; set; }
        DbSet<PromoModel> Promos { get; set; }
        DbSet<SpecialOffer> SpecialOffers { get; set; }
        DbSet<Discount> Discounts { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellation = default!);
    }
}
