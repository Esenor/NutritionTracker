using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;

namespace NutritionTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IUserListService _userListService;

        public TestController(ILogger<TestController> logger, IUserListService userListService)
        {
            _logger = logger;
            _userListService = userListService;
        }

        [HttpGet()]
        public Task<IEnumerable<User>> Get()
        {
            return _userListService.List();
        }
    }
}
