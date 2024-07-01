using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Sticker { get; set; }
    }
}