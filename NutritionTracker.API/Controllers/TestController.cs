using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Authentication.AuthorizeAttributes;

namespace NutritionTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(ILogger<TestController> logger, IUserListService userListService) : ControllerBase
    {
        private readonly ILogger<TestController> logger = logger;
        private readonly IUserListService userListService = userListService;

        [HttpGet()]
        [Authorize()]
        public Task<IEnumerable<User>> Get()
        {
            return userListService.List();
        }

        [HttpGet("everyone")]
        public string GetA()
        {
            return "Everyone";
        }

        [HttpGet("all-user")]
        [UserAuthorize()]
        public string GetB()
        {
            return "All user";
        }

        [HttpGet("user-only")]
        [UserAuthorize("USER")]
        public string GetC()
        {
            return "User only";
        }

        [HttpGet("admin-only")]
        [UserAuthorize("ADMIN")]
        public string GetD()
        {
            return "Admin only";
        }

        [HttpGet("guest-user-only")]
        [UserAuthorize("GUEST , USER  ")]
        public string GetE()
        {
            return "Guest user only";
        }
    }
}
