using Quizzen.Domain.Requests;

namespace Quizzen.Application.Abstracts
{
    public interface IEmailService
    {
        public Task SendEmail(EmailRequest emailRequest);
    }
}
