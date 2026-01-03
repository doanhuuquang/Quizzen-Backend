namespace Quizzen.Domain.Requests
{
    public record SendOTPToEmailRequest
    {
        public required string Email { get; init; }
    }
}
