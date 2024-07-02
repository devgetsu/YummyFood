using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class Discount : AudiTable
    {
        public int Persentage { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
    }
}
