using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // GET api/manufacturers
        [HttpGet]
        public ActionResult<IEnumerable<ManufacturerDTO>> Get()
        {
            return new List<ManufacturerDTO>(_manufacturerService.GetAllManufacturers());
        }

        // POST api/manufacturers
        [HttpPost]
        public void Post([FromBody] ManufacturerDTO manufacturer)
        {
            _manufacturerService.AddManufacturer(manufacturer);
        }

        // PUT api/manufacturers
        [HttpPut]
        public void Put([FromBody] ManufacturerDTO manufacturer)
        {
            _manufacturerService.UpdateManufacturer(manufacturer);
        }

        // DELETE api/manufacturers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var manufacturer = _manufacturerService
                .GetAllManufacturers()
                .FirstOrDefault(m => m.ManufacturerId == id);

            _manufacturerService.DeleteManufacturer(manufacturer);
        }
    }
}
