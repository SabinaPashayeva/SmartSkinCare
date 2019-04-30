using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApplicationUserDTO GetApplicationUserById(string userId)
        {
            var user = _userRepository
                .FindByCondition(u => u.Id == userId)
                .FirstOrDefault();

            if (user == null)
            {
                return default(ApplicationUserDTO);
            }

            var userDto = new ApplicationUserDTO
            {
                UserId = user.Id,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            };

            return userDto;
        }

        public IEnumerable<ApplicationUserDTO> GetAllUsers()
        {
            var userIds = _userRepository.FindAll().Select(s => s.Id);
            var users = new List<ApplicationUserDTO>();

            foreach (var id in userIds)
            {
                users.Add(GetApplicationUserById(id));
            }

            return users;
        }
    }
}
