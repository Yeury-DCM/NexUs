using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using NexUs.Core.Application.Dtos.Email;
using NexUs.Core.Domain.Settings;
using NexUs.Core.Application.Interfaces.Services;

namespace NexUs.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {

        private MailSettings _mailSettings { get; }

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(_mailSettings.DisplayName + " <" + _mailSettings.EmailFrom + ">");
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                BodyBuilder builder = new();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();

                using SmtpClient smtp = new SmtpClient();
                {
                    smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
            }
            catch(Exception ex)
            {

            }
        }

    }
}
