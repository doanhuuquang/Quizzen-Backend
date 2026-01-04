using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizzen.API.ApiResponse;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.DTOs.Requests;
using Quizzen.Domain.DTOs.Responses;
using Quizzen.Domain.Entities;

namespace Quizzen.API.Controllers
{
    [Route("api/otp")]
    [ApiController]
    public class OTPController(IOTPService otpService) : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendOTPToEmail(SendOTPToEmailRequest sendOTPToEmailRequest)
        {
            await otpService.SendOTPToEmailAsync(sendOTPToEmailRequest);

            var response = new SuccessResponse<object?>(
                StatusCode: 200,
                Message: "The OTP code has been successfully sent to your email.",
                Data: null,
                Timestamp: DateTime.UtcNow
            );

            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPRequest verifyOTPRequest)
        {
            var resetPasswordToken = await otpService.VerifyOTPAsync(verifyOTPRequest);

            var response = new SuccessResponse<VerifyOTPResponse?>(
                StatusCode: 200,
                Message: "OTP verified successfully.",
                Data: new VerifyOTPResponse { ResetToken = resetPasswordToken ?? "" },
                Timestamp: DateTime.UtcNow
            );

            return Ok(response);
        }
    }
}
