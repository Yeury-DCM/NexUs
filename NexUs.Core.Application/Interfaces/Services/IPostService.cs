using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IPostService : IGenericService<PostViewModel, SavePostViewModel, Post>
    {
        Task<List<PostViewModel>> GetAllViewModelByUser(string userId);
    }
}
