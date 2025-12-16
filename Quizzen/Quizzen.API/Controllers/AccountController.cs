using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzen.API.ApiResponse;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.Requests;

namespace Quizzen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            await accountService.RegisterAsync(registerRequest);

            var response = new SuccessResponse<object?>(
                StatusCode  : 200,
                Message     : "Register successful.",
                Data        : null,
                Timestamp   : DateTime.UtcNow
            );

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            await accountService.LoginAsync(loginRequest);

            var response = new SuccessResponse<object?>(
                StatusCode  : 200,
                Message     : "Login successful.",
                Data        : null,
                Timestamp   : DateTime.UtcNow
            );

            return Ok(response);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = HttpContext.Request.Cookies["REFRESH_TOKEN"];

            await accountService.LogoutAsync(refreshToken);

            var response = new SuccessResponse<object?>(
                StatusCode: 200,
                Message: "Logout successful.",
                Data: null,
                Timestamp: DateTime.UtcNow
            );

            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = HttpContext.Request.Cookies["REFRESH_TOKEN"];

            await accountService.RefreshTokenAsync(refreshToken);

            var response = new SuccessResponse<object?>(
                StatusCode  : 200,
                Message     : "Refresh token successful.",
                Data        : null,
                Timestamp   : DateTime.UtcNow
            );

            return Ok(response);
        }
    }
}
