using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.Entities;
using System.Threading.Tasks;
using SmartSkinCare.BusinessLogic.Authentication;

namespace SmartSkinCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("register")]
        public async Task Register(ApplicationUser user)
        {
            await _authorizationService.RegisterAsync(user, Response);
        }

        [HttpPost("login")]
        public async Task Login(AuthenticationModel user)
        {
            await _authorizationService.Login(user, Response);
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            await _authorizationService.LogOut();
        }
    }
}
