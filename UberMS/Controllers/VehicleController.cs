using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.VehicleDTOs;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public VehicleController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDto dto)
        {
            var isDriver = await _repo.UserRepository.IsDriver(dto.DriverId);

            if (!isDriver)
                return BadRequest("This user is not driver");

            var vehicle = _mapper.Map<Vehicle>(dto);

            await _repo.VehicleRepository.Add(vehicle);

            await _repo.SaveChanges();



            return CreatedAtAction("Create", new { Id = vehicle.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,VehicleUpdateDto dto)
        {
            var vehicle = await _repo.VehicleRepository.GetById(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            _mapper.Map(dto, vehicle);

            _repo.VehicleRepository.Update(vehicle);

            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _repo.VehicleRepository.GetById(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            _repo.VehicleRepository.Delete(vehicle);

            await _repo.SaveChanges();

            return NoContent();
        }
    }
}
