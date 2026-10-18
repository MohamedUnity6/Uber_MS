using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberMS.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Model { get; set; }
        [Required,MaxLength(20)]
        public int PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }
        public User Driver { get; set; }
    }
}
