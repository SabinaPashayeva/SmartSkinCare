using System;
using System.Collections.Generic;
using System.Linq;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;
using SmartSkinCare.BusinessLogic.SkinAnalyser;

namespace SmartSkinCare.BusinessLogic.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ICreamService _creamService;
        private readonly UserContext _userContext;
        private readonly ISkinAnalyser _skinAnalyser;

        private const int PossibleDifferenceOfAges = 5;

        public RecommendationService(ICreamService creamService,
             UserContext userContext,
             ISkinAnalyser skinAnalyser)
        {
            _creamService = creamService;
            _userContext = userContext;
            _skinAnalyser = skinAnalyser;
        }

        public IEnumerable<CreamDTO> GetRecommendedCream()
        {
            var creamsByAge = GetRecommendedCreamByAge();
            var creamsByTypeId = GetRecommendedCreamsBySkinType().Select(c => c.CreamId);

            if (creamsByAge == default(IEnumerable<CreamDTO>) ||
                creamsByTypeId == default(IEnumerable<string>))
            {
                return default(IEnumerable<CreamDTO>);
            }

            var resultListOfCreams = new List<CreamDTO>();

            foreach (var cream in creamsByAge)
            {
                if (creamsByTypeId.Contains(cream.CreamId))
                {
                    resultListOfCreams.Add(cream);
                }
            }

            return resultListOfCreams;
        }

        public IEnumerable<CreamDTO> GetRecommendedCreamByAge()
        {
            var creamsOfUser = _creamService.GetCreamsOfUser();
            var ageOfUser = _userContext.Age;

            var recommendedCreams = new List<CreamDTO>();

            if (ageOfUser == -1 || creamsOfUser == null)
            {
                return default(IEnumerable<CreamDTO>);
            }

            foreach (var cream in creamsOfUser)
            {
                if (cream.RecommendedAge == 0) continue;

                var actualDifference = Math.Abs(cream.RecommendedAge - ageOfUser);
                if (cream.RecommendedAge == ageOfUser ||
                    actualDifference <= PossibleDifferenceOfAges)
                {
                    recommendedCreams.Add(cream);
                }
            }

            return recommendedCreams;
        }

        public IEnumerable<CreamDTO> GetRecommendedCreamsBySkinType()
        {
            var creamsOfUser = _creamService.GetCreamsOfUser();
            var typeOfSkin = _skinAnalyser.GetCurrentTypeOfSkin();

            var creamsByType = creamsOfUser.Where(c => c.TypeOfSkin == typeOfSkin);

            return creamsByType;
        }
    }
}
