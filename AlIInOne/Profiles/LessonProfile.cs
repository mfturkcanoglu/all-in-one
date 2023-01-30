using AlIInOne.Dtos;
using AlIInOne.Models;
using AutoMapper;

namespace AlIInOne.Profiles
{
    public class LessonProfile : Profile
    {
        protected LessonProfile()
        {
            CreateMap<LessonCreateDto, Lesson>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.Code,
                    opt => opt.MapFrom(src => src.Code)
                )
                .ForMember(
                    dest => dest.Branch,
                    opt => opt.MapFrom(src => src.Branch)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.LecturerId,
                    opt => opt.MapFrom(src => src.LecturerId)
                )
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now))
                )
                .ForMember(
                    dest => dest.InitialLessonDate,
                    opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now).AddMonths(6))
                )
                .ForMember(
                    dest => dest.EndLessonDate,
                    opt => opt.MapFrom(src => DateTime.Now.AddMonths(6))
                )
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => false)
                );

            CreateMap<LessonUpdateDto, Lesson>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.Code,
                    opt => opt.MapFrom(src => src.Code)
                )
                .ForMember(
                    dest => dest.Branch,
                    opt => opt.MapFrom(src => src.Branch)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                );
        }
    }
}
