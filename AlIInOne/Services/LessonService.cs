using AlIInOne.Dtos;
using AlIInOne.Models;
using AlIInOne.Repositories;
using AlIInOne.Services.Base;
using AutoMapper;

namespace AlIInOne.Services
{
    public class LessonService : BaseService<Lesson, ILessonRepository>, ILessonService
    {
        private readonly IMapper mapper;
        public LessonService(ILessonRepository repository, IMapper mapper) : base(repository)
        {
            this.mapper = mapper;
        }

        public async Task<Lesson> CreateForSemester(LessonCreateDto dto)
        {
            // Register lesson
            var lesson = mapper.Map<Lesson>(dto);
            lesson = await Create(lesson);
            // TODO: READ STUDENTS FROM EXCEL
            return lesson;
        }
    }
}
