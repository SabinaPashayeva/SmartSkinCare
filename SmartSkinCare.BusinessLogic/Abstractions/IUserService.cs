using System;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IUserService
    {
        ApplicationUserDTO GetApplicationUserById(string userId);
    }
}
