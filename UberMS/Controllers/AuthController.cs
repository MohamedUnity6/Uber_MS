using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.UserDtos;
using UberMS.Heplers;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _repo;

        public AuthController(ITokenHelper tokenHelper, IUnitOfWork repo)
        {
            _tokenHelper = tokenHelper;
            _repo = repo;
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var user = await _repo.UserRepository.GetUserByEmail(dto.Email);

            if (user == null)
                return NotFound("User not found");

            if (user.Password != dto.Password)
                return Unauthorized();

            var token = _tokenHelper.GenerateToken(user);

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,
                Role = dto.Role
            };

            await _repo.UserRepository.Add(user);

            await _repo.SaveChanges();

            return CreatedAtAction("Register", new { Id = user.Id });
        }
    }
}
