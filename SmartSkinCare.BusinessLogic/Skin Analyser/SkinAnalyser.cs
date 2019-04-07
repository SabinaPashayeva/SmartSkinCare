using System;
using SmartSkinCare.BusinessLogic.Abstractions;

namespace SmartSkinCare.BusinessLogic.SkinAnalyser
{
    public class SkinAnalyser : ISkinAnalyser
    {
        private readonly UserContext _userContext;
        private readonly ISkinHumidityService _skinHumidityService;
        private readonly ISkinOilinessService _skinOilinessService;

        private const int MinimalHumidity = 40;
        private const int MinimalOiliness = 40;
        private const int MaximumRecommendedOiliness = 70;

        public SkinAnalyser(UserContext userContext,
            ISkinHumidityService skinHumidityService,
            ISkinOilinessService skinOilinessService)
        {
            _userContext = userContext;
            _skinHumidityService = skinHumidityService;
            _skinOilinessService = skinOilinessService;
        }

        public string GetCurrentTypeOfSkin()
        {
            var humidity = (int)Math.Round(GetAverageSkinHumidity());
            var oiliness = (int)Math.Round(GetAverageSkinOilinesses());

            if (humidity < MinimalHumidity && oiliness < MinimalOiliness)
            {
                return TypeOfSkin.Dry.ToFriendlyString();
            }

            if (humidity < MinimalHumidity && oiliness > MaximumRecommendedOiliness)
            {
                return TypeOfSkin.Combinated.ToFriendlyString();
            }

            if (humidity > MinimalHumidity && oiliness > MaximumRecommendedOiliness)
            {
                return TypeOfSkin.Combinated.ToFriendlyString();
            }

            return TypeOfSkin.Normal.ToFriendlyString();
        }

        private double GetAverageSkinHumidity()
        {
            var userId = _userContext.UserId;
            var humiditiesOfUser = _skinHumidityService.GetSkinHumiditiesForUser(userId);

            double lastHumidities = 0;
            var countForHumidities = 5;

            foreach (var humidity in humiditiesOfUser)
            {
                if (countForHumidities-- > 0)
                {
                    lastHumidities += humidity.SkinHumidityValue;
                }
            }

            return lastHumidities / countForHumidities;
        }

        private double GetAverageSkinOilinesses()
        {
            var userId = _userContext.UserId;
            var oilinessOfUser = _skinOilinessService.GetSkinOilinessForUser(userId);

            double lastOilinesses = 0;
            var countForOilinesses = 5;

            foreach (var oiliness in oilinessOfUser)
            {
                if (countForOilinesses-- > 0)
                {
                    lastOilinesses += oiliness.SkinOilinessValue;
                }
            }

            return lastOilinesses / countForOilinesses;
        }
    }
}
