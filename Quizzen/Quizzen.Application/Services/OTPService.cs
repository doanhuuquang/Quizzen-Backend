using Microsoft.AspNetCore.Identity;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.Entities;
using Quizzen.Domain.Exceptions;
using Quizzen.Domain.Requests;

namespace Quizzen.Application.Services
{
    public class OTPService(UserManager<User> userManager, IOTPRepository otpRepository, IEmailProcessor emailProcessor) : IOTPService
    {
        public async Task SendOTPToEmailAsync(SendOTPToEmailRequest sendOTPToEmailRequest)
        {
            var userExists = await userManager.FindByEmailAsync(sendOTPToEmailRequest.Email);

            if (userExists is null) throw new UserNotExistsException(email: sendOTPToEmailRequest.Email);
            else
            {
                var otp = await otpRepository.CreateOTPAsync(sendOTPToEmailRequest.Email) ?? throw new OTPException("Failed to generate OTP. Please try again");

                var emailRequest = new EmailRequest
                {
                    Receptor = sendOTPToEmailRequest.Email,
                    subject = "Reset password",
                    body = $"Hello {userExists.FirstName},\n\nYour OTP is: {otp.Code}\n\nBest regards,\nQuizzen Team"
                };
                await emailProcessor.SendEmail(emailRequest);
            }
        }

        public async Task VerifyOTPAsync(VerifyOTPRequest verifyOTPRequest)
        {
            var otp = await otpRepository.GetOTPAsync(verifyOTPRequest.Email) ?? throw new OTPException("Invalid or expired OTP. Please request a new one.");
            
            if (otp.Code != verifyOTPRequest.Code) throw new OTPException("Invalid OTP. Please try again.");

            otp.IsUsed = true;

            await otpRepository.UpdateOTPAsync(otp);
        }
    }
}
