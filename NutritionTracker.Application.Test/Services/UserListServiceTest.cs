using Moq;
using NutritionTracker.Application.Services;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;
using System.Text;

namespace NutritionTracker.Application.Test.Services
{
    public class UserListServiceTest
    {
        [Fact]
        public async Task List()
        {
            Mock<IUserRepository> mockUserRepository = new();

            IEnumerable<User> inputUsers = [
                new User(1, "admin@localhost", "azeccc", Encoding.Unicode.GetBytes("zeiouzz"), User.AdminRole, true),
                new User(2, "user@localhost", "qsdqf", Encoding.Unicode.GetBytes("oiuzeghiozeh"), User.UserRole, false),
            ];

            IEnumerable<User> expectedUsers = [
                new User(1, "admin@localhost", "azeccc", Encoding.Unicode.GetBytes("zeiouzz"), User.AdminRole, true),
                new User(2, "user@localhost", "qsdqf", Encoding.Unicode.GetBytes("oiuzeghiozeh"), User.UserRole, false),
            ];

            mockUserRepository.Setup(r => r.ListAll()).ReturnsAsync(inputUsers);

            UserListService service = new UserListService(mockUserRepository.Object);

            IEnumerable<User> actualUsers = await service.List();

            Assert.Equivalent(expectedUsers, actualUsers);
        }
    }
}
