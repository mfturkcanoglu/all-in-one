namespace AlIInOne.Dtos
{
    public class LessonCreateDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Branch { get; set; }
        // TODO: take lecturerId from token, later
        private IFormFile StudentListFile { get; set; }
        public Guid LecturerId { get; set; }
    }
}
