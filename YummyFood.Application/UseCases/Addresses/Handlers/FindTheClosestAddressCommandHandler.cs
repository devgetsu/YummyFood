using MediatR;
using Microsoft.EntityFrameworkCore;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Addresses.Commands;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Addresses.Handlers
{
    public class FindTheClosestAddressCommandHandler : IRequestHandler<FindTheClosestAddressCommand, object>
    {
        private readonly IApplicationDbContext _context;

        public FindTheClosestAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> Handle(FindTheClosestAddressCommand request, CancellationToken cancellationToken)
        {
            var nearestShop = await Task.Run(() =>
            {
                return _context.Shops
                    .Include(shop => shop.Address)
                    .AsEnumerable()
                    .Select(shop => new
                    {
                        Shop = shop,
                        Distance = GetDistance(request.Letitude, request.Longitude, shop.Address.Letitude, shop.Address.Longitude)
                    })
                    .OrderBy(result => result.Distance)
                    .FirstOrDefault();
            });

            if (nearestShop == null)
            {
                throw new _404NotFoundException("Shop Not found.");
            }

            return new
            {
                Shop = nearestShop.Shop,
                Distance = nearestShop.Distance
            };
        }

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371;
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;
            return distance;
        }

        public static double ToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }
    }
}
