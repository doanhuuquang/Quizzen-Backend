namespace Quizzen.Domain.Requests
{
    public record RegisterRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string FirstName { get; init; }
        public string? MidName { get; init; }
        public required string LastName { get; init; }
    }
}
