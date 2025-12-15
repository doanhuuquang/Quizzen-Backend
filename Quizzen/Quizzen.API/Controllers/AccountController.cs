using Microsoft.AspNetCore.Mvc;
using Quizzen.Application.Abstracts;
using Quizzen.Application.Services;
using Quizzen.Domain.Requests;

namespace Quizzen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            await accountService.RegisterAsync(registerRequest);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            await accountService.LoginAsync(loginRequest);

            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = HttpContext.Request.Cookies["REFRESH_TOKEN"];

            await accountService.RefreshTokenAsync(refreshToken);

            return Ok();
        }
    }
}
