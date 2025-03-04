using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Domain.Settings;
using NexUs.Infrastructure.Shared.Services;


namespace NexUs.Infrastructure.Shared
{
    public static class ServiceRegistration
    {

        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            #endregion
        }

    }
}
