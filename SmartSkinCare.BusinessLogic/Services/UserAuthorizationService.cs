using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Authentication;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic
{
    public class UserAuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public UserAuthorizationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(ApplicationUser userRegisterRequestModel,
            HttpResponse response)
        {
            var result = await _userManager.CreateAsync(userRegisterRequestModel,
                userRegisterRequestModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userRegisterRequestModel, false);
                await Login(new AuthenticationModel
                {
                    UserName = userRegisterRequestModel.UserName,
                    Password = userRegisterRequestModel.Password
                }, response);
            }

            await response.WriteAsync("Result validation failed!");
        }

        public async Task Login(AuthenticationModel model,
            HttpResponse response)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                    };

                var jwtSecurityToken = new JwtSecurityToken(
                    AuthenticationSettings.ISSUER,
                    AuthenticationSettings.AUDIENCE,
                    claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthenticationSettings.LIFETIME)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.KEY)),
                        SecurityAlgorithms.HmacSha256));

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                response.ContentType = "application/json";
                var responseJson = new
                {
                    access_token = encodedJwt,
                    username = user.UserName
                };

                await response.WriteAsync(JsonConvert.SerializeObject(responseJson,
                    new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented
                    }));

                return;
            }

            await response.WriteAsync("Wrong credentials!");
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
