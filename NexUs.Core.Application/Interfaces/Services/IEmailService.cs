using NexUs.Core.Application.Dtos.Email;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
