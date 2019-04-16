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
    public class SkinOilinessController : ControllerBase
    {
        private readonly ISkinOilinessService _skinOilinessService;
        private readonly UserContext _userContext;

        public SkinOilinessController(ISkinOilinessService skinOilinessService,
            UserContext userContext)
        {
            _skinOilinessService = skinOilinessService;
            _userContext = userContext;
        }

        // GET api/skinoiliness
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<SkinOilinessDTO>> Get()
        {
            return new List<SkinOilinessDTO>(_skinOilinessService
                .GetSkinOilinessForUser(_userContext.UserId));
        }

        // POST api/skinoiliness
        [Authorize(Roles = "IoT")]
        [HttpPost]
        public void Post([FromBody] SkinOilinessDTO skinOiliness)
        {
            _skinOilinessService.AddSkinOiliness(skinOiliness);
        }
    }
}
