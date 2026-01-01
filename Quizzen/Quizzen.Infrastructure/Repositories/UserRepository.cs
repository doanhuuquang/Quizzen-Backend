using Microsoft.EntityFrameworkCore;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.Entities;

namespace Quizzen.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
    {
        public async Task<User?> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return user;
        }
    }
}   
