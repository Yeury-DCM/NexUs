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
    public class PostService : GenericService<PostViewModel, SavePostViewModel, Post>, IPostService
    {
        IPostRepository _postRepository;
        IUserService _userService;

        public PostService(IPostRepository repository, IUserService userService,  IMapper mapper) : base(repository, mapper)
        {
            _postRepository = repository;
            _userService = userService;
        }

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {
            List<PostViewModel> posts = await base.GetAllViewModel();
            foreach(PostViewModel post in posts)
            {
                post.User = await _userService.GetById(post.UserId);

                foreach(CommentViewModel comment in post.Comments)
                {
                    comment.User = await _userService.GetById(comment.UserId);
                }
            }

            
            return posts;
        }


    }
}
