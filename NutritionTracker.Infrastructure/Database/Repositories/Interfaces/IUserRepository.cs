using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Infrastructure.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> ListAll();

        public User Add(User user);

        public User? FindByEmail(string email);
        public User? FindByEmailAndId(string email, int id);
    }
}
