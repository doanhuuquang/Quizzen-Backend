using Quizzen.Domain.Entities;

namespace Quizzen.Application.Abstracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
