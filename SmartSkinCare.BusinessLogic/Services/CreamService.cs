using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Models;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.BusinessLogic.Services
{
    public class CreamService : ICreamService
    {
        private readonly ICreamRepository _creamRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreamService(ICreamRepository creamRepository,
            IManufacturerRepository manufacturerRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _creamRepository = creamRepository;
            _manufacturerRepository = manufacturerRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddCream(CreamDTO creamDto)
        {
            _creamRepository.Create(GetEntityFromDto(creamDto));

            _creamRepository.Save();
        }

        public void UpdateCream(CreamDTO creamDto)
        {
            _creamRepository.Update(GetEntityFromDto(creamDto));

            _creamRepository.Save();
        }

        public void RemoveCream(CreamDTO creamDto)
        {
            _creamRepository.Delete(GetEntityFromDto(creamDto));

            _creamRepository.Save();
        }

        public IEnumerable<CreamDTO> GetAllCreams()
        {
            var allCreams = new List<CreamDTO>();
            var creams = _creamRepository.FindAll();

            foreach (var cream in creams)
            {
                allCreams.Add(GetDTOFromEntity(cream));
            }

            return allCreams;
        }

        private Cream GetEntityFromDto(CreamDTO creamDto)
        {
            var manufacturer = _manufacturerRepository
               .FindByCondition(m => m.Name == creamDto.ManufacturerName)
               .FirstOrDefault();

            var user = _userRepository
                .FindByCondition(u => u.Id == creamDto.UserId)
                .FirstOrDefault();

            var cream = _mapper.Map<Cream>(creamDto);

            cream.ManufacturerId = manufacturer.ManufacturerId;
            cream.Manufacturer = manufacturer;

            cream.ApplicationUser = user;

            return cream;
        }

        private CreamDTO GetDTOFromEntity(Cream cream)
        {
            var dto = _mapper.Map<CreamDTO>(cream);

            var manufacturerName = _manufacturerRepository
                .FindByCondition(m => m.ManufacturerId == cream.ManufacturerId)
                .FirstOrDefault()
                .Name;

            dto.ManufacturerName = manufacturerName;
            dto.UserId = cream.ApplicationUser.Id;

            return dto;
        }
    }
}
