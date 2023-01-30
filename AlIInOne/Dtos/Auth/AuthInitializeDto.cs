using AlIInOne.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlIInOne.Dtos.Auth
{
    public class AuthInitializeDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Identity { get; set; } = string.Empty;
        [Required]
        public UserType UserType { get; set; } = UserType.ADMIN;
    }
}
