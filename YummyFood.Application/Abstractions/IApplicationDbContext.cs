using Microsoft.EntityFrameworkCore;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<AdminApp> Admins { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<CommentModel> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<PromoModel> Promos { get; set; }
        DbSet<SpecialOfferModel> SpecialOffers { get; set; }
        DbSet<Discount> Discounts { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellation = default!);
    }
}
