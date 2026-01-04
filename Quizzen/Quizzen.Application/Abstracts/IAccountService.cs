using Quizzen.Domain.DTOs.Requests;
using System.Security.Claims;

namespace Quizzen.Application.Abstracts
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterRequest registerRequest);

        Task LoginAsync(LoginRequest loginRequest);

        Task LogoutAsync(string? refreshToken);

        Task RefreshTokenAsync(string? refreshToken);

        Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal);

        Task LoginWithFacebookAsync(ClaimsPrincipal? claimsPrincipal);

        Task LoginWithMicrosoftAsync(ClaimsPrincipal? claimsPrincipal);

        Task RecoverUsernameAsync(RecoverUsernameRequest recoverUsernameRequest);

        Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);
        
    }
}
