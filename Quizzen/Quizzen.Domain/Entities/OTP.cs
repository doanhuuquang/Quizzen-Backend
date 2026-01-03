namespace Quizzen.Domain.Entities
{
    public class OTP
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime ExpiresAtUtc { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public Boolean IsUsed { get; set; }
    }
}
