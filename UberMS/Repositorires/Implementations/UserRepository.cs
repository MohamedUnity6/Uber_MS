using Microsoft.EntityFrameworkCore;
using UberMS.Data;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Repositorires.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetByName(string name)
        {
            var result = await _context.Users.Where(u => u.Role == "Rider" && u.FullName.ToLower().Contains(name.ToLower())).ToListAsync();

            return result;
        }

        public async Task<List<User>> GetDrivers()
        {
            var result = await _context.Users.Where(u => u.Role == "Driver").ToListAsync();

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return result;
        }

        public async Task<bool> IsDriver(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return result.Role == "Driver";
        }

        public async Task<bool> IsRider(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return result.Role == "Rider";
        }
    }
}
