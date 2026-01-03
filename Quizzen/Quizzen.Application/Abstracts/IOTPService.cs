using Quizzen.Domain.Requests;

namespace Quizzen.Application.Abstracts
{
    public interface IOTPService
    {
        public Task SendOTPToEmailAsync(SendOTPToEmailRequest sendOTPToEmailRequest);
        public Task VerifyOTPAsync(VerifyOTPRequest verifyOTPRequest);
    }
}
