using AlIInOne.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlIInOne.Models
{
    [Table(name: "lessons")]
    public class Lesson : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Branch { get; set; }
        public DateOnly InitialLessonDate { get; set; }
        public DateOnly EndLessonDate { get; set; }
        [Required]
        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<LessonStudent> LessonStudents { get; set; }
    }
}
