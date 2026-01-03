namespace Quizzen.Domain.Requests
{
    public record RecoverUsernameRequest
    {
        public required string Email { get; init; }
    }
}
