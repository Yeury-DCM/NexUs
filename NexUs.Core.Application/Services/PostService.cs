using AutoMapper;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Comments;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Domain.Entities;
using NexUs.Core.Domain.Result;
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
        IMapper _mapper;

        public PostService(IPostRepository repository, IUserService userService,  IMapper mapper) : base(repository, mapper)
        {
            _postRepository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<PostViewModel>> GetAllViewModelByUser(string userId)
        {
            OperationResult<IQueryable<Post>> result = await _postRepository.GetAllAsync();


            List<Post> entities = result.Data!.Where(p => p.UserId == userId).OrderByDescending(p => p.DateTime).ToList();

            List<PostViewModel> postsViewModel = _mapper.Map<List<PostViewModel>>(entities);

            return await IncludUsersToPosts(postsViewModel);
        }

        private async Task<List<PostViewModel>> IncludUsersToPosts(List<PostViewModel> posts)
        {
            foreach (PostViewModel post in posts)
            {
                post.User = await _userService.GetById(post.UserId);

                foreach (CommentViewModel comment in post.Comments)
                {
                    comment.User = await _userService.GetById(comment.UserId);
                }
            }

            return posts;
        }
    }
}
