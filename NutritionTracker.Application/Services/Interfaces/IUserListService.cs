using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Application.Services.Interfaces
{
    public interface IUserListService
    {
        public Task<IEnumerable<User>> List();
    }
}
