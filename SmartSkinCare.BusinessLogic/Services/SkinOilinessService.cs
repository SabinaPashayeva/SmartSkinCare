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
    public class SkinOilinessService : ISkinOilinessService
    {
        private readonly IOilinessRepository _oilinessRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SkinOilinessService(IOilinessRepository oilinessRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _oilinessRepository = oilinessRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddSkinOiliness(SkinOilinessDTO oilinessDTO)
        {
            var oiliness = GetSkinOilinessFromDTO(oilinessDTO);

            if (oiliness != null)
            {
                _oilinessRepository.Create(oiliness);
            }

            _oilinessRepository.Save();
        }

        public IEnumerable<SkinOilinessDTO> GetSkinOilinessForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return default(IEnumerable<SkinOilinessDTO>);
            }

            var oilinessesOfUser = _oilinessRepository
                .FindByCondition(h => h.ApplicationUser.Id == userId);

            if (oilinessesOfUser == null)
            {
                return default(IEnumerable<SkinOilinessDTO>);
            }

            try
            {
                var oilinessDTOs = _mapper.Map<SkinOilinessDTO[]>(oilinessesOfUser);

                foreach (var oiliness in oilinessDTOs)
                {
                    oiliness.ApplicationUserId = userId;
                }

                return oilinessDTOs;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                return default(IEnumerable<SkinOilinessDTO>);
            }
        }

        private SkinOiliness GetSkinOilinessFromDTO(SkinOilinessDTO oilinessDTO)
        {
            if (oilinessDTO == null)
            {
                return default(SkinOiliness);
            }

            var user = _userRepository
                .FindByCondition(u => u.Id == oilinessDTO.ApplicationUserId)
                .FirstOrDefault();

            if (user == null)
            {
                return default(SkinOiliness);
            }

            try
            {
                var oiliness = _mapper.Map<SkinOiliness>(oilinessDTO);
                oiliness.ApplicationUser = user;

                return oiliness;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
                return default(SkinOiliness);
            }
        }
    }
}
