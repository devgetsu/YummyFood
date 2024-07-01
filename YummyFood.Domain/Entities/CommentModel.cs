using Microsoft.AspNetCore.Identity;
using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class CommentModel : AudiTable
    {
        public int Rate { get; set; }
        public long UserAppId { get; set; }
        public string? Feedback { get; set; }

        public UserApp UserApp { get; set; }
    }
}