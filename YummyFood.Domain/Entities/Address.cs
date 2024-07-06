using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string? Name { get; set; }
        public long Letitude { get; set; }
        public long Longitude { get; set; }
        public long? UserId { get; set; }
        public UserApp? User { get; set; }
    }
}