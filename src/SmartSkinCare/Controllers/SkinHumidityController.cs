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
    public class SkinHumidityController : ControllerBase
    {
        private readonly ISkinHumidityService _skinHumidityService;
        private readonly UserContext _userContext;

        public SkinHumidityController(ISkinHumidityService skinHumidityService,
            UserContext userContext)
        {
            _skinHumidityService = skinHumidityService;
            _userContext = userContext;
        }

        // GET api/skinhumidity
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<SkinHumidityDTO>> Get()
        {
            return new List<SkinHumidityDTO>(_skinHumidityService
                .GetSkinHumiditiesForUser(_userContext.UserId));
        }

        // POST api/skinhumidity
        [Authorize(Roles = "IoT")]
        [HttpPost]
        public void Post([FromBody] SkinHumidityDTO skinHumidity)
        {
            _skinHumidityService.AddSkinHumidity(skinHumidity);
        }
    }
}
