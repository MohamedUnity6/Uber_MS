using AutoMapper;
using UberMS.DTOs.UserDtos;
using UberMS.Models;

namespace UberMS.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
        }
    }

}
