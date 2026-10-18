using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.RideDTOs;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public RideController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RideCreateDto dto)
        {
            var isRider = await _repo.UserRepository.IsRider(dto.RiderId);
            var isDriver = await _repo.UserRepository.IsDriver(dto.DriverId);

            if (!isDriver)
                return NotFound("The user is not driver");

            if(!isRider)
                return NotFound("The user is not rider");

            var ride = _mapper.Map<Ride>(dto);

            await _repo.RideRepository.Add(ride);
            await _repo.SaveChanges();

            return CreatedAtAction("Create", new { Id = ride.Id });
        }

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string soryBy)
        {
            var rides = await _repo.RideRepository.Paggination(pageNumber, pageSize, soryBy);

            var ridesDto = _mapper.Map<List<RideResponseDto>>(rides);

            return Ok(ridesDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var ride = await _repo.RideRepository.GetById(id);

            if (ride == null)
                return NotFound("Ride not found");

            var rideDto = _mapper.Map<RideResponseDto>(ride);

            return Ok(rideDto);

        }

        [HttpPatch("accept/{id}")]

        public async Task<IActionResult> Accepted(int id)
        {
            var ride = await _repo.RideRepository.GetById(id);

            if (ride == null)
                return NotFound("Ride not found");

            ride.Status = "Accepted";

            _repo.RideRepository.Update(ride);

            await _repo.SaveChanges();

            var rideDto = _mapper.Map<RideResponseDto>(ride);

            return Ok(rideDto);

        }

        [HttpPatch("complete/{id}")]

        public async Task<IActionResult> Completed(int id)
        {
            var ride = await _repo.RideRepository.GetById(id);

            if (ride == null)
                return NotFound("Ride not found");

            ride.Status = "Completed";

            _repo.RideRepository.Update(ride);

            await _repo.SaveChanges();

            var rideDto = _mapper.Map<RideResponseDto>(ride);

            return Ok(rideDto);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var ride = await _repo.RideRepository.GetById(id);

            if (ride == null)
                return NotFound("Ride not found");

            _repo.RideRepository.Delete(ride);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("pickupSpot")]

        public async Task<IActionResult> Search(string pickup)
        {
            var rides = await _repo.RideRepository.GetByPickUpSpot(pickup);

            var ridesDto = _mapper.Map<List<RideResponseDto>>(rides);

            return Ok(ridesDto);
        }

        [HttpGet("filter")]

        public async Task<IActionResult> Filter(string status, int minFare, int maxFare, string sortBy)
        {
            var rides = await _repo.RideRepository.Filter(minFare, maxFare, sortBy, status);

            var ridesDto = _mapper.Map<List<RideResponseDto>>(rides);

            return Ok(ridesDto);
        }

        [HttpGet("report")]

        public async Task<IActionResult> Report()
        {
            var report = await _repo.RideRepository.Report();

            return Ok(report);
        }

    }
}
