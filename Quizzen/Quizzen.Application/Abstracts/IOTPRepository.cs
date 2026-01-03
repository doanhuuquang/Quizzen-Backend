using Quizzen.Domain.Entities;

namespace Quizzen.Application.Abstracts
{
    public interface IOTPRepository
    {
        public Task<OTP?> CreateOTPAsync(string email);
        public Task<OTP?> GetOTPAsync(string email);
        public Task UpdateOTPAsync(OTP otp);
    }
}
