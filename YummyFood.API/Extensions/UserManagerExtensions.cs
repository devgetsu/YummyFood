using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<UserApp> FindByPhoneNumberAsync(this UserManager<UserApp> userManager, string phoneNumber)
        {
            var result = await userManager.Users
                .FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber);

            return result!;
        }
    }
}
