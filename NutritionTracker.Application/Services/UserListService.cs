using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;

namespace NutritionTracker.Application.Services
{
    public class UserListService(IUserRepository userRepository) : IUserListService
    {
        private readonly IUserRepository userRepository = userRepository;

        public Task<IEnumerable<User>> List()
        {
            return userRepository.ListAll();
        }
    }
}
