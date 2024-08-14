using Microsoft.Extensions.DependencyInjection;
using NutritionTracker.Application.Services;
using NutritionTracker.Application.Services.Interfaces;

namespace NutritionTracker.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserListService, UserListService>();
            services.AddScoped<IPasswordService, PasswordService>();
        }
    }
}
