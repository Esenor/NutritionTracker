using Microsoft.Extensions.DependencyInjection;
using NutritionTracker.Data;

namespace NutritionTracker.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddDataSourceContext(this IServiceCollection services)
        {
            services.AddDbContext<DataDbContext>();
        }
    }
}
