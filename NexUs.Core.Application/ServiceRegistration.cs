
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.Services;
using System.Reflection;

namespace NexUs.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();
            serviceCollection.AddTransient<IPostService, PostService>();

        }
    }
}
