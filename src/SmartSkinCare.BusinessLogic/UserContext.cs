using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SmartSkinCare.BusinessLogic.Abstractions;

namespace SmartSkinCare.BusinessLogic
{
    public class UserContext
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string UserId => _httpContextAccessor
            .HttpContext
            .User
            .FindFirstValue(ClaimTypes.Sid);

        public int Age => GetAgeOfUser();

        public UserContext(IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetAgeOfUser()
        {
            if (UserId == null)
            {
                return -1;
            }

            var user = _userService.GetApplicationUserById(UserId);

            return DateTimeOffset.UtcNow.Year - user.DateOfBirth.Year;
        }
    }
}
