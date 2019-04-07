using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface ISkinOilinessService
    {
        void AddSkinOiliness(SkinOilinessDTO oilinessDTO);
        IEnumerable<SkinOilinessDTO> GetSkinOilinessForUser(string userId);
    }
}
