using NexUs.Core.Application.ViewModels.Comments;
using NexUs.Core.Domain.Entities;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface ICommentService : IGenericService<CommentViewModel, SaveCommentViewModel, Comment>
    {
    }
}
