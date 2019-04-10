using System;
using System.Collections.Generic;
using AutoMapper;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public void AddManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var manufacturer = GetManufacturerFromDTO(manufacturerDTO);

            if (manufacturer != null)
            {
                _manufacturerRepository.Create(manufacturer);
            }

            _manufacturerRepository.Save();
        }

        public void UpdateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var manufacturer = GetManufacturerFromDTO(manufacturerDTO);

            if (manufacturer != null)
            {
                _manufacturerRepository.Update(manufacturer);
            }

            _manufacturerRepository.Save();
        }

        public void DeleteManufacturer(ManufacturerDTO manufacturerDTO)
        {
            var manufacturer = GetManufacturerFromDTO(manufacturerDTO);

            if (manufacturer != null)
            {
                _manufacturerRepository.Delete(manufacturer);
            }

            _manufacturerRepository.Save();
        }

        public IEnumerable<ManufacturerDTO> GetAllManufacturers()
        {
            var manufacturers = _manufacturerRepository.FindAll();

            return _mapper.Map<ManufacturerDTO[]>(manufacturers);
        }

        private Manufacturer GetManufacturerFromDTO(ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return default(Manufacturer);
            }

            try
            {
                return _mapper.Map<Manufacturer>(manufacturerDTO);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                return default(Manufacturer);
            }
        }
    }
}
