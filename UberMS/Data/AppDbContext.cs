using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UberMS.Models;

namespace UberMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.RiderRides)
                .WithOne(r => r.Rider)
                .HasForeignKey(r => r.RiderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.DriverRides)
                .WithOne(r => r.Driver)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Vehicle)
                .WithOne(r => r.Driver)
                .HasForeignKey<Vehicle>(r => r.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Payment)
                .WithOne(p => p.Ride)
                .HasForeignKey<Payment>(p => p.RideId);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Rating)
                .WithOne(ra => ra.Ride)
                .HasForeignKey<Rating>(ra => ra.RideId);

        }
    }
}
