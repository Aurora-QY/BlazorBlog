using AuroraQY.BlazorBlog.Application.DTOs;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<int> CreateUserAsync(UserDto userDto, string password);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
