using AlIInOne.Dtos;
using AlIInOne.Models;
using AlIInOne.Services.Base;

namespace AlIInOne.Services
{
    public interface ILessonService : IBaseService<Lesson>
    {
        Task<Lesson> CreateForSemester(LessonCreateDto createDto);
    }
}
