using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;

namespace NutritionTracker.Application.Services
{
    public class UserListService : IUserListService
    {
        private readonly IUserRepository _userRepository;

        public UserListService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> List()
        {
            return _userRepository.ListAll();
        }
    }
}
