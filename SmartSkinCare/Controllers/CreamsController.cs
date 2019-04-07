using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreamsController : ControllerBase
    {
        private readonly ICreamService _creamService;
        private readonly UserContext _userContext;

        public CreamsController(ICreamService creamService, UserContext userContext)
        {
            _creamService = creamService;
            _userContext = userContext;
        }

        // GET api/creams
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [HttpGet]
        public ActionResult<IEnumerable<CreamDTO>> Get()
        {
            return new List<CreamDTO>(_creamService.GetAllCreams());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CreamDTO cream)
        {
            _creamService.AddCream(cream);
        }
    }
}
