using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Salting.Api
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
        public ActionResult<string> SingUp([FromBody] SignUpRequest request)
        {
            var result = _authService.SingUp(request);

            if (result is null)
                return UnprocessableEntity("User already exists");

            return Ok(result);
        }

        [HttpPost("log-in")]
        public ActionResult<string> LogIn([FromBody] LogInRequest request)
        {
            var result = _authService.LogIn(request);

            if (result is null)
                return UnprocessableEntity("Credentials not found or incorrect");

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<UserCredentials>> GetAllUsers()
        {
            return _authService.ReturnAllUsers();
        }

        
    }
}
