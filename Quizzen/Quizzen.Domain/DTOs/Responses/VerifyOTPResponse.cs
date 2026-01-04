namespace Quizzen.Domain.DTOs.Responses
{
    public record VerifyOTPResponse
    {
        public required string ResetToken { get; init; }
    }
}
