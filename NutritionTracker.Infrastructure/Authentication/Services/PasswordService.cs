using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace NutritionTracker.Infrastructure.Authentication.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly int keySize = 64;
        private readonly int iterations = 400000;
        private readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

        public byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(keySize);
        }

        public string HashPassword(string password, byte[] salt)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations, hashAlgorithm, keySize);
            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, byte[] salt, string hash)
        {
            byte[] hashToVerify = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations, hashAlgorithm, keySize);
            return Convert.ToHexString(hashToVerify) == hash;
        }
    }
}
