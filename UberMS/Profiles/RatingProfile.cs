using AutoMapper;
using UberMS.DTOs.RatingDTOd;
using UberMS.Models;

namespace UberMS.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingCreateDto, Rating>();
        }
    }
}
