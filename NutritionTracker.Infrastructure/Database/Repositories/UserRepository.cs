using Microsoft.EntityFrameworkCore;
using NutritionTracker.Data;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;

namespace NutritionTracker.Infrastructure.Database.Repositories
{
    public class UserRepository(DataDbContext dataDbContext) : IUserRepository
    {
        private readonly DataDbContext _dataDbContext = dataDbContext;

        public async Task<IEnumerable<User>> ListAll()
        {
            return await _dataDbContext.Users.ToListAsync();
        }

        public User Add(User user)
        {
            _dataDbContext.Users.Add(user);
            _dataDbContext.SaveChanges();
            return user;
        }
    }
}
