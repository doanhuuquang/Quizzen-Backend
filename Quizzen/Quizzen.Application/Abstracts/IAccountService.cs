using Quizzen.Domain.Requests;

namespace Quizzen.Application.Abstracts
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterRequest registerRequest);
        Task LoginAsync(LoginRequest loginRequest);
        Task LogoutAsync(string? refreshToken);
        Task RefreshTokenAsync(string? refreshToken);
    }
}
