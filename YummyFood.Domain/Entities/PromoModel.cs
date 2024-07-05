using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class PromoModel : AudiTable
    {
        public string Code { get; set; }
        public string Condition { get; set; }
    }
}
