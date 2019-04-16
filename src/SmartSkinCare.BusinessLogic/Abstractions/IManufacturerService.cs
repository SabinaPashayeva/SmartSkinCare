using System;
using System.Collections.Generic;
using SmartSkinCare.BusinessLogic.Models;

namespace SmartSkinCare.BusinessLogic.Abstractions
{
    public interface IManufacturerService
    {
        void AddManufacturer(ManufacturerDTO manufacturerDTO);
        void UpdateManufacturer(ManufacturerDTO manufacturerDTO);
        void DeleteManufacturer(ManufacturerDTO manufacturerDTO);
        IEnumerable<ManufacturerDTO> GetAllManufacturers();
    }
}
