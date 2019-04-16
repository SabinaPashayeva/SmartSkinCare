using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic.SkinAnalyser;

namespace SmartSkinCare.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SkinTypeController : ControllerBase
    {
        private readonly ISkinAnalyser _skinAnalyser;

        public SkinTypeController(ISkinAnalyser skinAnalyser)
        {
            _skinAnalyser = skinAnalyser;
        }

        // GET api/type
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _skinAnalyser.GetCurrentTypeOfSkin();
        }
    }
}
