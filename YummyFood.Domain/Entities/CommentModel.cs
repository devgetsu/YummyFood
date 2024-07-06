using Microsoft.AspNetCore.Identity;
using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class CommentModel : AudiTable
    {
        public short Rate { get; set; }
        public string? Feedback { get; set; }
        public long ShopId { get; set; }
        public long UserId { get; set; }

        public Shop Shop { get; set; }
        public UserApp User { get; set; }
    }
}