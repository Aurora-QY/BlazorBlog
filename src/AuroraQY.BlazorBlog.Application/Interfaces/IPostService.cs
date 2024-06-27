using System.Collections.Generic;
using System.Threading.Tasks;
using AuroraQY.BlazorBlog.Application.DTOs;

namespace AuroraQY.BlazorBlog.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<IEnumerable<PostDto>> GetLatestPostsAsync(int count);
        Task<int> CreatePostAsync(PostDto postDto);
        Task UpdatePostAsync(PostDto postDto);
        Task DeletePostAsync(int id);
    }
}
