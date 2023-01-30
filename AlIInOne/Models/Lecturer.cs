using AlIInOne.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlIInOne.Models
{
    [Table(name: "lecturers")]
    public class Lecturer : BaseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Identity { get; set; } = string.Empty;

        public virtual ICollection<Lesson> Lessons { get; set; }
        //public Guid UserId { get; set; }
        //public User User { get; set; }
    }
}
