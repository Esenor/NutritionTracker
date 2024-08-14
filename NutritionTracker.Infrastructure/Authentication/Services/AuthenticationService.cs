using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutritionTracker.Infrastructure.Authentication.Services
{
    public class AuthenticationService(IConfiguration config) : IAuthenticationService
    {
        private readonly IConfiguration config = config;
        public string Login(string email, string password)
        {
            if (email == "" || password == "")
            {
                return string.Empty;
            }

            JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(config.GetSection("Values").GetSection("JwtSecret").Value ?? "");
            var aaaa = ClaimTypes.Email;
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Email, $"Email placeholder: {email}"),
                    new("sub", "1"),
                ]),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
