namespace NutritionTracker.Infrastructure.Authentication.Services.Interfaces
{
    public interface IPasswordService
    {
        public string HashPassword(string password, byte[] salt);
        public bool VerifyPassword(string password, byte[] salt, string hash);
        public byte[] GenerateSalt();

    }
}
