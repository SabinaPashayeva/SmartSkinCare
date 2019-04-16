using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IRecommendationService
    {
        IEnumerable<CreamDTO> GetRecommendedCream();
        IEnumerable<CreamDTO> GetRecommendedCreamByAge();
        IEnumerable<CreamDTO> GetRecommendedCreamsBySkinType();
    }
}
