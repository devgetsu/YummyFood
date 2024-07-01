using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.Abstractions.AuthServices
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserApp user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWTSettings:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName.Split(" ")[0]),
                new Claim(ClaimTypes.Surname, user.FullName.Split(" ")[1]),
                new Claim(ClaimTypes.Role, user.Role!)
            };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWTSettings:ValidIssuer"],
                audience: _config["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
