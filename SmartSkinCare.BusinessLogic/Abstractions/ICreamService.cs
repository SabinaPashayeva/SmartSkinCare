using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface ICreamService
    {
        void AddCream(CreamDTO creamDto);
        void UpdateCream(CreamDTO creamDto);
        void RemoveCream(CreamDTO creamDto);
        IEnumerable<CreamDTO> GetAllCreams();
        void Save();
    }
}
