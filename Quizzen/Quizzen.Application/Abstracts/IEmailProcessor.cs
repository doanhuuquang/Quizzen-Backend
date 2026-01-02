using Quizzen.Domain.Requests;

namespace Quizzen.Application.Abstracts
{
    public interface IEmailProcessor
    {
        public Task SendEmail(EmailRequest emailRequest);
    }
}
