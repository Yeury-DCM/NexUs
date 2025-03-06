using AutoMapper;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Comments;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Services
{
    public class CommentService : GenericService<CommentViewModel, SaveCommentViewModel, Comment>, ICommentService
    {
     
        ICommentRepository _postRepository;
        IUserService _userService;

        public CommentService(ICommentRepository repository, IUserService userService, IMapper mapper) : base(repository, mapper)
        {
            _postRepository = repository;
            _userService = userService;
        }

        public override async Task<List<CommentViewModel>> GetAllViewModel()
        {
            List<CommentViewModel> comments = await base.GetAllViewModel();

            foreach (CommentViewModel comment in comments)
            {
                comment.User = await _userService.GetById(comment.UserId);
            }

            return comments;
        }
    }
}
