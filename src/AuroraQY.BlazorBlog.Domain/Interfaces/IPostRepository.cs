using AuroraQY.BlazorBlog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
    }
}
