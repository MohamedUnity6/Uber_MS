using System.ComponentModel.DataAnnotations;

namespace UberMS.DTOs.UserDtos
{
    public class RegisterRequestDto
    {
        [Required, Length(3, 100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required, Phone]

        public string Phone { get; set; }
        [Required, AllowedValues("Driver", "Rider")]

        public string Role { get; set; }
    }
}
