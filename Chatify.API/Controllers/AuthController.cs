using Chatify.Core.Dtos.AuthDtos;
using Chatify.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService )
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await authService.RegisterUser(registerDto);
            if (!result.IsSucceeded)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.Login(loginDto);
            // Unauthorized
            if (!result.IsSucceeded)
                return Unauthorized(result.Message);

            Response.Cookies.Append("AuthToken", result.Data, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddHours(1)
            });
            return Ok(result.Message);
        }
    }
}
