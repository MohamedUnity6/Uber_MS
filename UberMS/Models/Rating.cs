using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberMS.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
        [ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
        public Ride Ride { get; set; }
    }
}
