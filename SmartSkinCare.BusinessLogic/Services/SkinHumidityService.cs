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
    public class SkinHumidityService : ISkinHumidityService
    {
        private readonly IHumidityRepository _humidityRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SkinHumidityService(IHumidityRepository humidityRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _humidityRepository = humidityRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void AddSkinHumidity(SkinHumidityDTO humidityDTO)
        {
            var humidity = GetSkinHumidityFromDTO(humidityDTO);

            if (humidity != null)
            {
                _humidityRepository.Create(humidity);
            }
        }

        public IEnumerable<SkinHumidityDTO> GetSkinHumiditiesForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return default(ICollection<SkinHumidityDTO>);
            }

            var humiditiesOfUser = _humidityRepository
                .FindByCondition(h => h.ApplicationUser.Id == userId);

            if (humiditiesOfUser == null)
            {
                return default(ICollection<SkinHumidityDTO>);
            }

            try
            {
                var humidityDtos = _mapper.Map<SkinHumidityDTO[]>(humiditiesOfUser);

                foreach (var humidity in humidityDtos)
                {
                    humidity.ApplicationUserId = userId;
                }

                return humidityDtos;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                return default(ICollection<SkinHumidityDTO>);
            }
        }

        private SkinHumidity GetSkinHumidityFromDTO(SkinHumidityDTO humidityDTO)
        {
            if (humidityDTO == null || humidityDTO.SkinHumidityId == 0)
            {
                return default(SkinHumidity);
            }

            var user = _userRepository
                .FindByCondition(u => u.Id == humidityDTO.ApplicationUserId)
                .FirstOrDefault();

            if (user == null)
            {
                return default(SkinHumidity);
            }

            try
            {
                var humidity = _mapper.Map<SkinHumidity>(humidityDTO);
                humidity.ApplicationUser = user;

                return humidity;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                return default(SkinHumidity);
            }
        }
    }
}
