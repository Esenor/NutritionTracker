using Moq;
using NutritionTracker.Application.Services;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.Repositories.Interfaces;

namespace NutritionTracker.Application.Test.Services
{
    public class UserListServiceTest
    {
        [Fact]
        public async Task List()
        {
            Mock<IUserRepository> mockUserRepository = new();

            IEnumerable<User> inputUsers = [
                new User(1, "admin@localhost", "azeccc", "zeiouzz", ["ADMIN", "USER"], true),
                new User(2, "user@localhost", "qsdqf", "oiuzeghiozeh", ["USER"], false),
            ];

            IEnumerable<User> expectedUsers = [
                new User(1, "admin@localhost", "azeccc", "zeiouzz", ["ADMIN", "USER"], true),
                new User(2, "user@localhost", "qsdqf", "oiuzeghiozeh", ["USER"], false),
            ];

            mockUserRepository.Setup(r => r.ListAll()).ReturnsAsync(inputUsers);

            UserListService service = new UserListService(mockUserRepository.Object);

            IEnumerable<User> actualUsers = await service.List();

            Assert.Equivalent(expectedUsers, actualUsers);
        }
    }
}
