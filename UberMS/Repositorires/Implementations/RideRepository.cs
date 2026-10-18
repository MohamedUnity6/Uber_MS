using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using UberMS.Data;
using UberMS.DTOs.RideDTOs;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Repositorires.Implementations
{
    public class RideRepository : GenericRepository<Ride>, IRideRepository
    {
        private readonly AppDbContext _context;
        public RideRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Ride> OrderBy(IQueryable<Ride> result, string sortBy)
        {

            switch (sortBy.ToLower())
            {
                case "fare":
                    result = _context.Rides.OrderBy(r => r.Fare);
                    break;
                case "rating":
                    result = _context.Rides.OrderBy(r => r.Rating.Score);
                    break;
                default:
                    result = _context.Rides.OrderBy(r => r.Fare);
                    break;
            }

            return result;
        }

        public async Task<List<Ride>> Paggination(int page, int pageSize, string SortBy)
        {
            var result = _context.Rides.Include(r => r.Rating)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var newresult = await OrderBy(result, SortBy).Include(r => r.Driver).Include(r => r.Rider).ToListAsync();


            return newresult;
        }

        public override async Task<Ride> GetById(int id)
        {
            var result = await _context.Rides.Include(r => r.Driver).Include(r => r.Rider).FirstOrDefaultAsync(r => r.Id == id);

            return result;
        }

        public async Task<List<Ride>> GetByPickUpSpot(string pickup)
        {
            var result = await _context.Rides.Include(r => r.Driver).Include(r => r.Rider).Where(r => r.PickUpLocation.ToLower() == pickup.ToLower()).ToListAsync();

            return result;
        }

        public async Task<List<Ride>> Filter(int minFare, int maxFare, string sortBy, string status)
        {
            var result = _context.Rides.Where(r => r.Fare >= minFare && r.Fare <= maxFare && r.Status == status);

            var newResult = await OrderBy(result, sortBy).Include(r => r.Driver).Include(r => r.Rider).ToListAsync();

            return newResult;


        }

        public async Task<RideReportDto> Report()
        {
            var result = new RideReportDto
            {
                NumberOfRides = await _context.Rides.CountAsync(),
                TotalRevenue = await _context.Payments.SumAsync(p => p.Amount),
                AvergaeRevenue = await _context.Payments.AverageAsync(p => p.Amount),
                MostRideAmount = await _context.Payments.MaxAsync(p => p.Amount),
                LeastRideAmount = await _context.Payments.MinAsync(P => P.Amount),
                AverageRating = await _context.Ratings.AverageAsync(r => r.Score),
                MaxRating = await _context.Ratings.MaxAsync(r => r.Score),
                MinRating = await _context.Ratings.MinAsync(r => r.Score),
            };

           return result;
        }
    }
}
