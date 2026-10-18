using AutoMapper;
using UberMS.DTOs.VehicleDTOs;
using UberMS.Models;

namespace UberMS.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleDto, Vehicle>();

            CreateMap<VehicleUpdateDto, Vehicle>();
        }
    }
}
