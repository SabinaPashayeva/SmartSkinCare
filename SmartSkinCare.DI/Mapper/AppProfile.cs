﻿using System;
using AutoMapper;
using SmartSkinCare.BusinessLogic.Models;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DI.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Cream, CreamDTO>();
        }
    }
}