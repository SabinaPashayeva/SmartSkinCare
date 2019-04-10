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
        [HttpGet]
        public ActionResult<IEnumerable<CreamDTO>> Get()
        {
            return new List<CreamDTO>(_creamService.GetCreamsOfUser());
        }

        // GET api/creams/5
        [HttpGet("{id}")]
        public ActionResult<CreamDTO> Get(int id)
        {
            return _creamService.GetCreamById(id);
        }

        // GET api/creams/all
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public ActionResult<IEnumerable<CreamDTO>> GetAll()
        {
            return new List<CreamDTO>(_creamService.GetAllCreams());
        }

        // POST api/creams
        [HttpPost]
        public void Post([FromBody] CreamDTO cream)
        {
            _creamService.AddCream(cream);
        }

        // PUT api/creams/
        [HttpPut]
        public void Put([FromBody] CreamDTO cream)
        {
            _creamService.UpdateCream(cream);
        }

        // DELETE api/creams/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cream = _creamService.GetCreamById(id);

            _creamService.RemoveCream(cream);
        }
    }
}
