using AutoMapper;
using Core.Dtos.Concrete;
using Core.Entities.Concrete;

namespace CozProject.Business.Helpers
{
    public sealed class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<UpdateUserAdminDto, User>().ReverseMap();

        }
    }
}
