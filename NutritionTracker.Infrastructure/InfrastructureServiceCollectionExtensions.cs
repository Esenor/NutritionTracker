using Microsoft.Extensions.DependencyInjection;
using NutritionTracker.Data;
using NutritionTracker.Infrastructure.Database.Repositories;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;
using NutritionTracker.Infrastructure.Authentication.Services;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;

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

        public static void AddInfrastructureAuthentication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordService, PasswordService>();
        }
    }
}
