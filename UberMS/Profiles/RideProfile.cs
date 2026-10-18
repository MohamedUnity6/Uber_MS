using AutoMapper;
using Microsoft.Identity.Client.Extensibility;
using UberMS.DTOs.RideDTOs;
using UberMS.Models;

namespace UberMS.Profiles
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<RideCreateDto, Ride>();

            CreateMap<Ride, RideResponseDto>()
                .ForMember(dst => dst.DriverName, op => op.MapFrom(src => src.Driver.FullName))
                .ForMember(dst => dst.RiderName, op => op.MapFrom(src => src.Rider.FullName));
        }
    }
}
