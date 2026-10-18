using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UberMS.Models;

namespace UberMS.DTOs.RideDTOs
{
    public class RideCreateDto
    {
        [Required, MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Range(20, 5000)]
        public decimal Fare { get; set; }
        [Required]
        public string Status { get; set; }
        public int RiderId { get; set; }

        public int DriverId { get; set; }
    }
}
