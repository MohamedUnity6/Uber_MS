using Microsoft.AspNetCore.Mvc;
using UberMS.DTOs.RideDTOs;
using UberMS.Models;

namespace UberMS.Repositorires.Interfaces
{
    public interface IRideRepository : IGenericRepository<Ride>
    {
        Task<List<Ride>> Paggination(int page, int pageSize,string SortBy);

        IQueryable<Ride> OrderBy(IQueryable<Ride> result,string sortBy);

        Task<List<Ride>> GetByPickUpSpot(string pickup);

        Task<List<Ride>> Filter(int minFare,int maxFare,string sortBy,string status);

        Task<RideReportDto> Report();
    }
}
