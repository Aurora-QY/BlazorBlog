using AutoMapper;
using BCrypt.Net;
using AuroraQY.BlazorBlog.Application.DTOs;
using AuroraQY.BlazorBlog.Application.Interfaces;
using AuroraQY.BlazorBlog.Domain.Entities;
using AuroraQY.BlazorBlog.Domain.Interfaces;
using AuroraQY.BlazorBlog.Domain.ValueObjects;
using System.Threading.Tasks;

namespace AuroraQY.BlazorBlog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<int> CreateUserAsync(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            user.Email = new Email(userDto.Email);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            _mapper.Map(userDto, user);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
