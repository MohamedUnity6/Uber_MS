using AutoMapper;
using UberMS.DTOs.PaymentDTOs;
using UberMS.Models;

namespace UberMS.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateDto, Payment>();
        }
    }
}
