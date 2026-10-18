using System.ComponentModel.DataAnnotations;

namespace UberMS.DTOs.RideDTOs
{
    public class RideResponseDto
    {
        [Required, MaxLength(150)]
        public string PickUpLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Range(20, 5000)]
        public decimal Fare { get; set; }
        [Required]
        public string Status { get; set; }
        public string RiderName { get; set; }

        public string DriverName { get; set; }
    }
}
