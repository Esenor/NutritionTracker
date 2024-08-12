using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Application.Services.Interfaces
{
    public interface IUserList
    {
        public Task<IEnumerable<User>> List();
    }
}
