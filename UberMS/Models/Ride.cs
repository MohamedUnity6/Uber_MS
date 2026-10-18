using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace UberMS.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Range(20,5000)]
        public decimal Fare { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public User Rider { get; set; }
        [ForeignKey(nameof(Driver))]

        public int DriverId { get; set; }
        public User Driver { get; set; }

        public Payment? Payment { get; set; }

        public Rating? Rating { get; set; }
    }
}
