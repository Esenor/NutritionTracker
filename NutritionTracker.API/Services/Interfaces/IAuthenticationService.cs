namespace NutritionTracker.API.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string Login(string email, string password);
    }
}
