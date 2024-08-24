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
        public async Task<ActionResult<string>> SingUpAsync([FromBody] SignUpRequest request)
        {
            var result = await _authService.SingUpAsync(request);

            if (result is null)
                return UnprocessableEntity();

            return Ok(result);
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<string>> LogInAsync([FromBody] LogInRequest request)
        {
            var result = _authService.LogInAsync(request);

            if (result is null)
                return UnprocessableEntity();

            return Ok(result);
        }

        
    }
}
