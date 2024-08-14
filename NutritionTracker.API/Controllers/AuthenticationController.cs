using Microsoft.AspNetCore.Mvc;
using NutritionTracker.API.DTO.Authentication;
using NutritionTracker.Infrastructure.Authentication.Services.Interfaces;



namespace NutritionTracker.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController(ILogger<TestController> logger, IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly ILogger<TestController> logger = logger;
        private readonly IAuthenticationService authenticationService = authenticationService;

        [HttpPost("login")]
        public ActionResult<string> Login(AuthenticationLoginDTO authenticationLogin)
        {
            string token = authenticationService.Login(authenticationLogin.Email, authenticationLogin.Password);

            if (token == string.Empty)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
