using Microsoft.Extensions.Options;
using Quizzen.Application.Abstracts;
using Quizzen.Domain.DTOs.Requests;
using Quizzen.Infrastructure.Options;
using System.Net;
using System.Net.Mail;

namespace Quizzen.Infrastructure.Processors
{
    public class EmailProcessor(IOptions<EmailOptions> emailOptions) : IEmailProcessor
    {
        public async Task SendEmail(EmailRequest emailRequest)
        {
            var email       = emailOptions.Value.Email;
            var password    = emailOptions.Value.Password;
            var host        = emailOptions.Value.Host;
            var port        = int.Parse(emailOptions.Value.Port);

            var smtpClient  = new SmtpClient(host, port) 
            { 
                EnableSsl               = true, 
                UseDefaultCredentials   = false,
                Credentials             = new NetworkCredential(email, password)
            };

            var message = new MailMessage(email, emailRequest.Receptor, emailRequest.subject, emailRequest.body);

            await smtpClient.SendMailAsync(message);
        }
    }
}
