using Microsoft.Extensions.DependencyInjection;
using NutritionTracker.Data;
using NutritionTracker.Infrastructure.Database.Repositories;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;
using NutritionTracker.Infrastructure.Authentication.Services;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using NutritionTracker.Infrastructure.Authentication.AuthorizationHandler;
using Microsoft.AspNetCore.Authorization;
using NutritionTracker.Infrastructure.Authentication.PolicyProvider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NutritionTracker.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddDataSourceContext(this IServiceCollection services)
        {
            services.AddDbContext<DataDbContext>();
        }

        public static void AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
        }

        public static void AddInfrastructureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {          
            services.AddSingleton<IAuthorizationPolicyProvider, UserPolicyProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationHandler, UserAuthorizationHandler>();

            // Add JWT authentication and authorization
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Values:JwtSecret"] ?? "")),
                    LifetimeValidator = (before, expires, token, param) =>
                    {
                        return expires > DateTime.UtcNow;
                    },
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });
        }
    }
}
