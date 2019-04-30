using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IUserService
    {
        ApplicationUserDTO GetApplicationUserById(string userId);
        IEnumerable<ApplicationUserDTO> GetAllUsers();
    }
}
