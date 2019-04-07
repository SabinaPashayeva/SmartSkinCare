using System;
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
                DateOfBirth = user.DateOfBirth
            };

            return userDto;
        }
    }
}
