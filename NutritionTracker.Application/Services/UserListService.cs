using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Application.Services
{
    public class UserListService : IUserList
    {
        public Task<IEnumerable<User>> List()
        {
            List<User> users =
            [
                new User(1, "admin@email", "admin_hash", "admin_salt", ["admin"], false),
                new User(2, "user@email", "user_hash", "user_salt", ["user"], false)
            ];


            return Task.FromResult(users.AsEnumerable());
        }
    }
}
