
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Domain.Entities;
using NexUs.Infrastructure.Persistence.Contexts;

namespace NexUs.Infrastructure.Persistence.Repositories
{

    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context, ILogger<CommentRepository> logger) : base(context, logger)
        {
        }
    }
}
