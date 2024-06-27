using System.Collections.Generic;
using System.Threading.Tasks;
using AuroraQY.BlazorBlog.Application.DTOs;

namespace AuroraQY.BlazorBlog.Application.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDto>> GetAllPostsAsync();
        Task<BlogPostDto> GetPostByIdAsync(int id);
        Task CreatePostAsync(BlogPostDto postDto);
    }
}
