using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SmartSkinCare.Entities;

namespace SmartSkinCare.UserService.Authentication
{
    public class UserAuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAuthorizationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> RegisterAsync(ApplicationUser userRegisterRequestModel)
        {
            var user = new ApplicationUser
            {
                Email = userRegisterRequestModel.Email,
                UserName = userRegisterRequestModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userRegisterRequestModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return await Login(new AuthenticationModel
                {
                    UserName = userRegisterRequestModel.UserName,
                    Password = userRegisterRequestModel.Password
                });
            }

            return "Result validation failed!";
        }

        public async Task<string> Login(AuthenticationModel model)
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

                var response = new
                {
                    access_token = encodedJwt,
                    username = user.UserName
                };

                return JsonConvert.SerializeObject(response,
                    new JsonSerializerSettings { Formatting = Formatting.Indented });
            }

            return "Wrong credentials!";
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
