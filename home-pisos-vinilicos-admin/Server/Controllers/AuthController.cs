using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using home_pisos_vinilicos.Application.Services;
using home_pisos_vinilicos.Application.Services.Interfaces;

namespace home_pisos_vinilicos.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticationService.RegisterUserAsync(request.Email, request.Password);
            return Ok(result);
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Server is up and running!");
        }

        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello from the TestController!");
        }
     
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.LoginUserAsync(request.Email, request.Password);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return Unauthorized(result.Message);
        }
    
}

    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
