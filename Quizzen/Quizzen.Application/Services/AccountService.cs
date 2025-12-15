using Microsoft.AspNetCore.Identity;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.Entities;
using Quizzen.Domain.Exceptions;
using Quizzen.Domain.Requests;

namespace Quizzen.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAuthTokenProcessor authTokenProcessor;
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public AccountService(IAuthTokenProcessor authTokenProcessor, UserManager<User> userManager, IUserRepository userRepository)
        {
            this.authTokenProcessor = authTokenProcessor;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterRequest registerRequest)
        {
            var userExists = await userManager.FindByEmailAsync(registerRequest.Email);

            if (userExists is not null) throw new UserAlreadyExistsException(email: registerRequest.Email);

            var user = User.Create(registerRequest.Email, registerRequest.FirstName, registerRequest.LastName);
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, registerRequest.Password);

            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded) throw new RegistrationFailedException(result.Errors.Select(x => x.Description));
        }

        public async Task LoginAsync(LoginRequest loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Email);

            if (user is null) throw new LoginNotFoundAccountException(email: loginRequest.Email);
            if (user is not null && await userManager.CheckPasswordAsync(user, loginRequest.Password) == false) throw new LoginIncorrectPasswordException();

            var (jwtToken , expirationDateInUtc) = authTokenProcessor.GenerateJwtToken(user);
            var refreshTokenValue = authTokenProcessor.GenerateRefreshToken();

            var refreshTokenExpirationInUtc = DateTime.UtcNow.AddDays(30);

            user.RefreshToken = refreshTokenValue;
            user.RefreshTokenExpiresAtUtc = refreshTokenExpirationInUtc;

            await userManager.UpdateAsync(user);

            authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
            authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("REFRESH_TOKEN", refreshTokenValue, refreshTokenExpirationInUtc);
        }

        public async Task RefreshTokenAsync(string? refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken)) throw new RefreshTokenException("Refresh token is missing!");

            var user = await userRepository.GetUserByRefreshTokenAsync(refreshToken);

            if (user is null) throw new RefreshTokenException("Invalid refresh token!");

            if(user.RefreshTokenExpiresAtUtc < DateTime.UtcNow) throw new RefreshTokenException("Refresh token is expired!");

            var (jwtToken, expirationDateInUtc) = authTokenProcessor.GenerateJwtToken(user);
            var refreshTokenValue = authTokenProcessor.GenerateRefreshToken();

            var refreshTokenExpirationInUtc = DateTime.UtcNow.AddDays(30);

            user.RefreshToken = refreshTokenValue;
            user.RefreshTokenExpiresAtUtc = refreshTokenExpirationInUtc;

            await userManager.UpdateAsync(user);

            authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
            authTokenProcessor.WriteAuthTokenAsHttpOnlyCookie("REFRESH_TOKEN", refreshTokenValue, refreshTokenExpirationInUtc);
        }
    }
}
