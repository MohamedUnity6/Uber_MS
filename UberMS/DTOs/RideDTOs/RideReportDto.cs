namespace UberMS.DTOs.RideDTOs
{
    public class RideReportDto
    {
        public int NumberOfRides { get; set; }

        public decimal TotalRevenue { get; set; }
        public decimal AvergaeRevenue { get; set; }
        public decimal LeastRideAmount { get; set; }
        public decimal MostRideAmount { get; set; }

        public double AverageRating { get; set; }
        public decimal MaxRating {  get; set; }

        public decimal MinRating {  get; set; }

    }
}
