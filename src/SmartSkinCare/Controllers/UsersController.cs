using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserContext _userContext;

        public UsersController(IUserService userService, UserContext userContext)
        {
            _userService = userService;
            _userContext = userContext;
        }

        // GET api/users/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult<ApplicationUserDTO> Get(string id)
        {
            return _userService.GetApplicationUserById(id);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<ApplicationUserDTO> GetCurrentUserInfo()
        {
            return _userService.GetApplicationUserById(_userContext.UserId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public ActionResult<IEnumerable<ApplicationUserDTO>> GetAllUsers()
        {
            return new List<ApplicationUserDTO>(_userService.GetAllUsers());
        }
    }
}
