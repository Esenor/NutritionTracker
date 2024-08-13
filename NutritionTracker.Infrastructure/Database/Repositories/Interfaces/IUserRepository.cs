using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Infrastructure.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> ListAll();
    }
}
