using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Concrete;

namespace Core.Entities.MapperProfiles
{
    public sealed class CoreLayerProfile : Profile
    {
        public CoreLayerProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();

            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<UpdateUserAdminDto, User>().ReverseMap();
        }
    }
}
