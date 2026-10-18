using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberMS.DTOs.VehicleDTOs
{
    public class VehicleUpdateDto
    {
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required, MaxLength(20)]
        public int PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        public int DriverId { get; set; }
    }
}
