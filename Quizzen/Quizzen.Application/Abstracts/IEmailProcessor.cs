using Quizzen.Domain.DTOs.Requests;

namespace Quizzen.Application.Abstracts
{
    public interface IEmailProcessor
    {
        public Task SendEmail(EmailRequest emailRequest);
    }
}
