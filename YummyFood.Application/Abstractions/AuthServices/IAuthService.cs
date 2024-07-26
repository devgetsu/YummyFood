using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.Abstractions.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(UserApp user);
        public string GenerateTokenAdmin(AdminApp user);
    }
}
