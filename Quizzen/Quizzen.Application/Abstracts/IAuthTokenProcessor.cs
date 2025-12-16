using Quizzen.Domain.Entities;

namespace Quizzen.Application.Abstracts
{
    public interface IAuthTokenProcessor
    {
        public (string jwtToken, DateTime expiresAtUtc) GenerateJwtToken(User user);
        public string GenerateRefreshToken();
        public void WriteAuthTokenAsHttpOnlyCookie(string cookieName, string token, DateTime expiration);
        public void DeleteAuthTokenCookie(string cookieName);
    }
}
