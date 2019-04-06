using System;
using System.Threading.Tasks;
using SmartSkinCare.BusinessLogic.Authentication;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IAuthorizationService
    {
        Task<string> RegisterAsync(ApplicationUser userRegisterRequestModel);
        Task<string> Login(AuthenticationModel model);
        Task LogOff();
    }
}
