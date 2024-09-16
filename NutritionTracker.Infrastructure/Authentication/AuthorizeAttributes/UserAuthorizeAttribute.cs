using Microsoft.AspNetCore.Authorization;

namespace NutritionTracker.Infrastructure.Authentication.AuthorizeAttributes
{
    public class UserAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
    {
        public UserAuthorizeAttribute() { }
        public UserAuthorizeAttribute(string userRoles) => UserRoles = userRoles.ToUpper();
        public string? UserRoles { get; }

        public IEnumerable<IAuthorizationRequirement> GetRequirements()
        {
            yield return this;
        }
    }
}
