using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.RatingDTOd;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public RatingController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreateDto dto)
        {
            var ride = await _repo.RideRepository.GetById(dto.RideId);

            if (ride == null)
                return NotFound("Ride not found");

            var rating = _mapper.Map<Rating>(dto);

            await _repo.RatingRepository.Add(rating);
            await _repo.SaveChanges();

            return CreatedAtAction("Create", new { Id = rating.Id });
        }

    }
}
