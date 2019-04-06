using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreamsController
    {
        private readonly ICreamService _creamService;

        public CreamsController(ICreamService creamService)
        {
            _creamService = creamService;
        }

        // GET api/creams
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
