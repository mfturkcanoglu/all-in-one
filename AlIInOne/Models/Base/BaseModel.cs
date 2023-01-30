using System.ComponentModel.DataAnnotations;

namespace AlIInOne.Models.Base
{
    public class BaseModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? Deleted { get; set; }
    }
}
