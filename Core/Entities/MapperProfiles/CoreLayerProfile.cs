using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.MapperProfiles
{
    public class CoreLayerProfile : Profile
    {
        public CoreLayerProfile()
        {
            CreateMap<User, LoginedUserDto>();
            CreateMap<LoginedUserDto, User>();
            CreateMap<User, UpdateUserDto>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<UpdateUserAdminDto, User>();
        }
    }
}
