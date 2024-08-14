namespace NutritionTracker.API.DTO.Authentication
{
    public class AuthenticationSignUpDTO
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
    }
}
