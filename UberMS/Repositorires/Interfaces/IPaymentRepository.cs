using UberMS.DTOs.PaymentDTOs;
using UberMS.Models;

namespace UberMS.Repositorires.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<PaymentReportDto> Report();
    }
}
