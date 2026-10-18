using UberMS.Models;

namespace UberMS.Repositorires.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        Task<List<User>> GetDrivers();
        Task<List<User>> GetByName(string name);

        Task<bool> IsDriver(int id);
        Task<bool> IsRider(int id);
    }
}
