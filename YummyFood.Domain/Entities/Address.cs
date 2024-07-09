using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string? Name { get; set; }
        public float Letitude { get; set; }
        public float Longitude { get; set; }
        public long? UserId { get; set; }
        public UserApp? User { get; set; }
    }
}