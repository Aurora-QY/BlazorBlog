using System.Collections.Generic;
using System.Threading.Tasks;
using AuroraQY.BlazorBlog.Application.DTOs;
using AuroraQY.BlazorBlog.Domain.Services;

namespace AuroraQY.BlazorBlog.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostService(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllPostsAsync()
        {
            var posts = await _repository.GetAllAsync();
            return posts.Select(
                p =>
                    new BlogPostDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = p.Content
                    }
            );
        }

        public async Task<BlogPostDto> GetPostByIdAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            return new BlogPostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };
        }

        public async Task CreatePostAsync(BlogPostDto postDto)
        {
            var post = new BlogPost { Title = postDto.Title, Content = postDto.Content };
            await _repository.AddAsync(post);
        }
    }
}
