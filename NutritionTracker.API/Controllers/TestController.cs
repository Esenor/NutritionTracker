using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Application.Services.Interfaces;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;
using System.Text;

namespace NutritionTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IUserListService _userListService;
        private readonly IPasswordService _passwordService;

        public TestController(ILogger<TestController> logger, IUserListService userListService, IPasswordService passwordService)
        {
            _logger = logger;
            _userListService = userListService;
            _passwordService = passwordService;
        }

        [HttpGet()]
        [Authorize()]
        public Task<IEnumerable<User>> Get()
        {
            return _userListService.List();
        }

        [HttpGet("password")]
        public IList<string> GetDumbPassword()
        {
            IList<string> aa = [];
            byte[] salt = _passwordService.GenerateSalt();

            aa.Add(Encoding.ASCII.GetString(salt));
            aa.Add(_passwordService.HashPassword("admin", Encoding.ASCII.GetBytes(aa[0])));
            aa.Add(_passwordService.HashPassword("admin", Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(salt))));
            aa.Add("_____");
            aa.Add(_passwordService.HashPassword("admin", salt));
            aa.Add(_passwordService.HashPassword("admin", salt));

            return aa;
        }
    }
}
