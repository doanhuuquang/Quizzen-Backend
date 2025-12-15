using Quizzen.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzen.Application.Abstracts
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterRequest registerRequest);
        Task LoginAsync(LoginRequest loginRequest);
        Task RefreshTokenAsync(string? refreshToken);
    }
}
