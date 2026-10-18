using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UberMS.Models;

namespace UberMS.DTOs.PaymentDTOs
{
    public class PaymentCreateDto
    {
        [Range(20, 5000)]
        public decimal Amount { get; set; }
        [Required]

        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int RideId { get; set; }
    }
}
