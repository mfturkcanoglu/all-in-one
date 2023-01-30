using AlIInOne.Dtos;
using AlIInOne.Models;
using AutoMapper;

namespace AlIInOne.Profiles
{
    public class LecturerProfile : Profile
    {
        public LecturerProfile()
        {
            CreateMap<LecturerCreateDto, Lecturer>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now)
                )
                .ForMember(
                    dest => dest.Deleted,
                    opt => opt.MapFrom(src => false)
                );
        }
    }
}
