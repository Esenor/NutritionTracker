using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutritionTracker.Infrastructure.Authentication.Services
{
    public class AuthenticationService(IConfiguration config, IUserRepository userRepository, IPasswordService passwordService) : IAuthenticationService
    {
        private readonly IConfiguration config = config;
        private readonly IUserRepository userRepository = userRepository;
        private readonly IPasswordService passwordService = passwordService;
        public string Login(string email, string password)
        {
            if (email == "" || password == "")
            {
                return string.Empty;
            }

            var user = userRepository.FindByEmail(email);
            if (user == null) {
                return string.Empty;
            }

            if(!passwordService.VerifyPassword(password, user.Salt, user.Hash))
            {
                return string.Empty;
            }

            JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.ASCII.GetBytes(config.GetSection("Values").GetSection("JwtSecret").Value ?? "");

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Email, user.Email),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
