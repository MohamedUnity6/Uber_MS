using UberMS.Models;

namespace UberMS.Repositorires.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {  get; }
        IGenericRepository<Vehicle> VehicleRepository {  get; }
        IRideRepository RideRepository {  get; }
        IPaymentRepository PaymentRepository {  get; }
        IGenericRepository<Rating> RatingRepository {  get; }

        Task SaveChanges();
    }
}
