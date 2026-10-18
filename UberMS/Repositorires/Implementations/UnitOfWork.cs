using UberMS.Data;
using UberMS.Models;
using UberMS.Repositorires.Interfaces;

namespace UberMS.Repositorires.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }


        public IGenericRepository<Vehicle> VehicleRepository { get; }


        public IRideRepository RideRepository { get; }


        public IPaymentRepository PaymentRepository { get; }


        public IGenericRepository<Rating> RatingRepository { get; }

        private readonly AppDbContext _context;

        public UnitOfWork(IUserRepository userRepository, IGenericRepository<Vehicle> vehicleRepository, IRideRepository rideRepository, IPaymentRepository paymentRepository, IGenericRepository<Rating> ratingRepository, AppDbContext context)
        {
            UserRepository = userRepository;
            VehicleRepository = vehicleRepository;
            RideRepository = rideRepository;
            PaymentRepository = paymentRepository;
            RatingRepository = ratingRepository;
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
