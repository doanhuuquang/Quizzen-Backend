using Quizzen.Application.Abstracts;
using Quizzen.Domain.Requests;

namespace Quizzen.Application.Services
{
    public class EmailService(IEmailProcessor emailProcessor) : IEmailService
    {
        public async Task SendEmail(EmailRequest emailRequest)
        {
            await emailProcessor.SendEmail(emailRequest);
        }
    }
}
