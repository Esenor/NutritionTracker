using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NutritionTracker.Infrastructure.Authentication.AuthorizeAttributes;
namespace NutritionTracker.Infrastructure.Authentication.PolicyProvider
{
    public class UserPolicyProvider : IAuthorizationPolicyProvider
    {
        public const string POLICY_PREFIX = "UserPolicy";
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public UserPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return FallbackPolicyProvider.GetFallbackPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) && policyName.Substring(POLICY_PREFIX.Length) is string)
            {
                var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                policy.AddRequirements(new UserAuthorizeAttribute(policyName.Substring(POLICY_PREFIX.Length)));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy?>(null);
        }
    }
}
