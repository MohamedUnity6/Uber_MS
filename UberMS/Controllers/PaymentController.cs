using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.PaymentDTOs;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateDto dto)
        {
            var ride = await _repo.RideRepository.GetById(dto.RideId);

            if (ride == null)
                return NotFound("Ride not found");

            var payment = _mapper.Map<Payment>(dto);

            await _repo.PaymentRepository.Add(payment);

            await _repo.SaveChanges();

            return CreatedAtAction("Create", new { Id = payment.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Statistics()
        {
            var report = await _repo.PaymentRepository.Report();

            return Ok(report);
        }
    }
}
