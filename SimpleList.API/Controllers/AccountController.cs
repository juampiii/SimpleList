using Microsoft.AspNetCore.Mvc;
using SimpleList.Application.Contracts.Identity;
using SimpleList.Application.Models.Identity;

namespace SimpleList.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok(await _authService.LoginAsync(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.RegisterAsync(request));
        }
    }
}
