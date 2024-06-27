using AuroraQY.BlazorBlog.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> GetPostByIdAsync(int id);
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<int> CreatePostAsync(PostDto postDto, int authorId);
        Task UpdatePostAsync(PostDto postDto);
        Task DeletePostAsync(int id);
    }
}
