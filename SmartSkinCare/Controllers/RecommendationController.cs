using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        // GET api/recommendation
        [HttpGet]
        public ActionResult<IEnumerable<CreamDTO>> GetCream()
        {
            return new List<CreamDTO>(_recommendationService.GetRecommendedCream());
        }

        // GET api/recommendation/age
        [HttpGet("age")]
        public ActionResult<IEnumerable<CreamDTO>> GetCreamByAge()
        {
            return new List<CreamDTO>(_recommendationService.GetRecommendedCreamByAge());
        }

        // GET api/recommendation/type
        [HttpGet("type")]
        public ActionResult<IEnumerable<CreamDTO>> GetCreamByType()
        {
            return new List<CreamDTO>(_recommendationService.GetRecommendedCreamsBySkinType());
        }
    }
}
