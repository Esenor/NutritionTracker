using Microsoft.AspNetCore.Authorization;
using NutritionTracker.Infrastructure.Authentication.AuthorizeAttributes;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace NutritionTracker.Infrastructure.Authentication.AuthorizationHandler
{
    public class UserAuthorizationHandler(IUserRepository userRepository) : AuthorizationHandler<UserAuthorizeAttribute>
    {
        private readonly IUserRepository userRepository = userRepository;
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizeAttribute requirement)
        {
            var nameIdentifierClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            var subEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Email);
            IEnumerable<string> roles = [];

            // If the requirement is a string, split the string into an array of roles
            if (requirement.UserRoles is string)
            {
                // Remove all whitespace from the string and split the string by commas
                roles = Regex.Replace(requirement.UserRoles, @"\s+", "").Split(",");
            }

            // If the user is not authenticated, the claim will be null
            if (nameIdentifierClaim == null || subEmail == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // If the user is authenticated, but the claim is not an integer, the claim will be null
            int nameIdentifierValue = int.Parse(nameIdentifierClaim.Value);
            if (nameIdentifierValue < 1)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // If the user is authenticated, but the user is not found, the user will be null
            var user = userRepository.FindByEmailAndId(subEmail.Value, nameIdentifierValue);
            if (user == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // If the user is authenticated, but the user is not enabled, the user will be null
            if (user.Enabled == false)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // If the user is authenticated, but the user's role is not in the list of roles, the user will be null
            if (roles.Count() > 0 && roles.Contains(user.Role.ToUpper()) == false)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
