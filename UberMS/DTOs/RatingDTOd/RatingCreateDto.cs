using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UberMS.Models;

namespace UberMS.DTOs.RatingDTOd
{
    public class RatingCreateDto
    {
        [Range(1, 5)]
        public int Score { get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
    }
}
