using System.ComponentModel.DataAnnotations;

namespace UberMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, Length(3,100)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required,Phone]

        public string Phone {  get; set; }
        [Required,AllowedValues("Driver","Rider")]

        public string Role { get; set; }

        public Vehicle? Vehicle { get; set; }

        public ICollection<Ride>? RiderRides { get; set; }
        public ICollection<Ride>? DriverRides { get; set; }
    }
}
