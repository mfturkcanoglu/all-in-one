using AlIInOne.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlIInOne.Models
{
    [Table(name: "students")]
    public class Student : BaseModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string StudentIdentity { get; set; }
        public string? Email { get; set; } = string.Empty;
        //public Guid UserId { get; set; }
        //public User User { get; set; }
        public ICollection<LessonStudent> LessonStudents { get; set; }

    }
}
