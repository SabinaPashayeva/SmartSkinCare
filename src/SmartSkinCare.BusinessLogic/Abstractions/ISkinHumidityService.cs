using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface ISkinHumidityService
    {
        void AddSkinHumidity(SkinHumidityDTO humidityDTO);
        IEnumerable<SkinHumidityDTO> GetSkinHumiditiesForUser(string userId);
    }
}
