using Microsoft.EntityFrameworkCore;
using NutritionTracker.Data;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;

namespace NutritionTracker.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataDbContext _dataDbContext;

        public UserRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<IEnumerable<User>> ListAll()
        {
            return await _dataDbContext.Users.ToListAsync();
        }
    }
}
