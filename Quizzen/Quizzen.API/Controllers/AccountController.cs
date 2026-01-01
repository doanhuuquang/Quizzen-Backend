using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizzen.API.ApiResponse;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.Entities;
using Quizzen.Domain.Requests;

namespace Quizzen.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IAccountService accountService, SignInManager<User> signInManager, LinkGenerator linkGenerator) : ControllerBase
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

        [HttpGet("login/google")]
        public IActionResult LoginGoogle([FromQuery] string? returnUrl)
        {
            var redirectUrl = linkGenerator.GetPathByName(HttpContext, "GoogleLoginCallback");

            var properties = signInManager.ConfigureExternalAuthenticationProperties(
                GoogleDefaults.AuthenticationScheme,
                redirectUrl
            );

            properties.Items["returnUrl"] = returnUrl ?? "/";

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("login/google/callback", Name = "GoogleLoginCallback")]
        public async Task<IActionResult> LoginGoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!result.Succeeded) return Unauthorized();

            var returnUrl = result.Properties?.Items["returnUrl"] ?? "/";

            await accountService.LoginWithGoogleAsync(result.Principal);

            return Redirect(returnUrl);
        }

        [HttpGet("login/facebook")]
        public IActionResult LoginFacebook([FromQuery] string? returnUrl)
        {
            var redirectUrl = linkGenerator.GetPathByName(HttpContext, "FacebookLoginCallback");

            var properties = signInManager.ConfigureExternalAuthenticationProperties(
                FacebookDefaults.AuthenticationScheme,
                redirectUrl
            );

            properties.Items["returnUrl"] = returnUrl ?? "/";

            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("login/facebook/callback", Name = "FacebookLoginCallback")]
        public async Task<IActionResult> LoginFacebookCallback()
        {
            var result = await HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);

            if (!result.Succeeded) return Unauthorized();

            var returnUrl = result.Properties?.Items["returnUrl"] ?? "/";

            await accountService.LoginWithFacebookAsync(result.Principal);

            return Redirect(returnUrl);
        }
    }   
}
