using AuroraQY.BlazorBlog.Domain.Entities;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
