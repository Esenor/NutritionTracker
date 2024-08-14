namespace NutritionTracker.Infrastructure.Authentication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string Login(string email, string password);
    }
}
