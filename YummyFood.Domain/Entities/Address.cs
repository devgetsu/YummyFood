using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string? Name { get; set; }
        public long Letitude { get; set; }
        public long Longitude { get; set; }
    }
}