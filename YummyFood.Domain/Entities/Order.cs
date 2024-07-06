using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Domain.Enums;

namespace YummyFood.Domain.Entities
{
    public class Order : AudiTable
    {
        public long UserId { get; set; }
        public long RestaurantId { get; set; }
        public decimal ShippingFree { get; set; }
        public decimal TotalAmount { get; set; }

        public UserApp User { get; set; }
        public Shop Restaurant { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Products { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    }
}
