using LLS_Application.DTOs;
using LLS_Application.Interfaces;
using LLS_Domain.Entities;
using LLS_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLS_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("User not found");
            return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email };
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = new User { Username = userDto.Username, Email = userDto.Email };
            await _userRepository.AddAsync(user);
            return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email };
        }
    }
}
