using AutoMapper;
using Core.Dtos.Concrete;
using Core.Entities.Concrete;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;

namespace CozProject.Business.Helpers
{
    public sealed class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<UpdateUserAdminDto, User>().ReverseMap();

            CreateMap<AnswerReadDto, Answer>().ReverseMap();
            CreateMap<AnswerWriteDto, Answer>().ReverseMap();

            CreateMap<CategoryReadDto, Category>().ReverseMap();
            CreateMap<CategoryWriteDto, Category>().ReverseMap();

            CreateMap<CategoryCompleteReadDto, CategoryComplete>().ReverseMap();
            CreateMap<CategoryCompleteWriteDto, CategoryComplete>().ReverseMap();

            CreateMap<QuestionReadDto, Question>().ReverseMap();
            CreateMap<QuestionWriteDto, Question>().ReverseMap();

            CreateMap<QuestionCompleteReadDto, QuestionComplete>().ReverseMap();
            CreateMap<QuestionCompleteWriteDto, QuestionComplete>().ReverseMap();

        }
    }
}
