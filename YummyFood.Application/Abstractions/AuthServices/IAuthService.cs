using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.Abstractions.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(UserApp user);
    }
}
