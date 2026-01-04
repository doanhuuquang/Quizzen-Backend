using Quizzen.Domain.DTOs.Requests;
using Quizzen.Domain.Entities;

namespace Quizzen.Application.Abstracts
{
    public interface IOTPService
    {
        public Task SendOTPToEmailAsync(SendOTPToEmailRequest sendOTPToEmailRequest);
        public Task<string?> VerifyOTPAsync(VerifyOTPRequest verifyOTPRequest);
    }
}
