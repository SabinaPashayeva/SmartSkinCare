using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SmartSkinCare.UserService.Authentication
{
    public static class AuthenticationSettings
    {
        public static string ISSUER = "MyAuthServer";
        public static string AUDIENCE = "https://localhost:5000/";
        public static string KEY = "mysupersecret_secretkey!123";
        public static int LIFETIME = 15;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
