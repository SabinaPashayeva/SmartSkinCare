using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartSkinCare.BusinessLogic.Authentication;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IAuthorizationService
    {
        Task RegisterAsync(ApplicationUser userRegisterRequestModel, HttpResponse response);
        Task Login(AuthenticationModel model, HttpResponse response);
        Task LogOut();
    }
}
