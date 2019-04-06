using System;
using System.Threading.Tasks;
using SmartSkinCare.Entities;

namespace SmartSkinCare.UserService.Authentication
{
    public interface IAuthorizationService
    {
        Task<string> RegisterAsync(ApplicationUser userRegisterRequestModel);
        Task<string> Login(AuthenticationModel model);
        Task LogOff();
    }
}
