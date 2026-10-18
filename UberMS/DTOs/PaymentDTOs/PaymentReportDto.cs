namespace UberMS.DTOs.PaymentDTOs
{
    public class PaymentReportDto
    {
        public decimal TotalRevenue { get; set; }
        public decimal AvergaeRevenue { get; set; }
        public decimal LeastRideAmount { get; set; }
        public decimal MostRideAmount { get; set; }
    }
}
