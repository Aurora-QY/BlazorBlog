using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AuroraQY.BlazorBlog.Application.DTOs;
using AuroraQY.BlazorBlog.Application.Interfaces;
using AuroraQY.BlazorBlog.Domain.Entities;
using AuroraQY.BlazorBlog.Domain.Interfaces;
using System.Text.Json;

namespace AuroraQY.BlazorBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
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

        public async Task<IEnumerable<PostDto>> GetLatestPostsAsync(int count)
        {
            var posts = await _postRepository.GetLatestPostsAsync(count);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        // public async Task<IEnumerable<PostDto>> GetLatestPostsAsync(int count)
        // {
        //     var posts = await _postRepository.GetLatestPostsAsync(count);
        //     return posts
        //         .Select(
        //             p =>
        //                 new PostDto
        //                 {
        //                     Id = p.Id,
        //                     Title = p.Title,
        //                     Content = p.Content,
        //                     Summary = p.Summary,
        //                     ImageUrl = p.ImageUrl,
        //                     CreatedAt = p.CreatedAt,
        //                     UpdatedAt = p.UpdatedAt,
        //                     AuthorId = p.AuthorId,
        //                     AuthorName = p.Author?.Username
        //                 }
        //         )
        //         .ToList();
        // }

        public async Task<int> CreatePostAsync(PostDto postDto)
        {
            // 打印 postDto 的内容
            string postDtoJson = JsonSerializer.Serialize(
                postDto,
                new JsonSerializerOptions { WriteIndented = true }
            );
            Console.WriteLine($"postDto: {postDtoJson}");

            var post = _mapper.Map<Post>(postDto);
            post.CreatedAt = DateTime.UtcNow;
            await _postRepository.AddAsync(post);
            return post.Id;
        }

        public async Task UpdatePostAsync(PostDto postDto)
        {
            var post = await _postRepository.GetByIdAsync(postDto.Id);
            _mapper.Map(postDto, post);
            post.UpdatedAt = DateTime.UtcNow;
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
