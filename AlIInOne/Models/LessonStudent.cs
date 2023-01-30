using AlIInOne.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AlIInOne.Models
{
    public class LessonStudent : BaseModel
    {
        [Required]
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
