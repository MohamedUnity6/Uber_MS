using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.UserDtos;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("drivers")]
        [Authorize]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _repo.UserRepository.GetDrivers();

            var driversDto = _mapper.Map<List<UserResponseDto>>(drivers);

            return Ok(driversDto);
        }

        [HttpGet("riders")]
        
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            var ridersByName = await _repo.UserRepository.GetByName(name);

            var ridersDto = _mapper.Map<List<UserResponseDto>>(ridersByName);

            return Ok(ridersDto);
        }
    }
}
