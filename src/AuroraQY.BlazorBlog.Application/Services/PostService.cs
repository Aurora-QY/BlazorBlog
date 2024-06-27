using AutoMapper;
using AuroraQY.BlazorBlog.Application.DTOs;
using AuroraQY.BlazorBlog.Application.Interfaces;
using AuroraQY.BlazorBlog.Domain.Entities;
using AuroraQY.BlazorBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostService(
            IPostRepository postRepository,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<int> CreatePostAsync(PostDto postDto, int authorId)
        {
            var author = await _userRepository.GetByIdAsync(authorId);
            var post = _mapper.Map<Post>(postDto);
            post.Author = author;
            await _postRepository.AddAsync(post);
            return post.Id;
        }

        public async Task UpdatePostAsync(PostDto postDto)
        {
            var post = await _postRepository.GetByIdAsync(postDto.Id);
            _mapper.Map(postDto, post);
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
