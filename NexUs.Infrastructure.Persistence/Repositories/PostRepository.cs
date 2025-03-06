using Microsoft.Extensions.Logging;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Domain.Entities;
using NexUs.Infrastructure.Persistence.Contexts;


namespace NexUs.Infrastructure.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context, ILogger<PostRepository> logger) : base(context, logger)
        {
        }
    }
}
