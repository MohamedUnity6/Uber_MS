using Microsoft.EntityFrameworkCore;
using UberMS.Data;
using UberMS.DTOs.PaymentDTOs;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Repositorires.Implementations
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaymentReportDto> Report()
        {
            var result = new PaymentReportDto
            {
                TotalRevenue = await _context.Payments.SumAsync(p => p.Amount),
                AvergaeRevenue = await _context.Payments.AverageAsync(p => p.Amount),
                MostRideAmount = await _context.Payments.MaxAsync(p => p.Amount),
                LeastRideAmount = await _context.Payments.MinAsync(P => P.Amount),
            };

            return result;
        }
    }
}
