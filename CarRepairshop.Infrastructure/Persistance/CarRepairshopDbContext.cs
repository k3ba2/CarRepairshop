using CarRepairshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRepairshop.Infrastructure.Persistance
{
    public class CarRepairshopDbContext : DbContext
    {
        public CarRepairshopDbContext(DbContextOptions<CarRepairshopDbContext> options) : base(options)
        {
        }

        public DbSet<CarRepairshop.Domain.Entities.CarRepairshop> CarRepairshops { get; set; }
        public DbSet<ArchivedCarRepairshop> ArchivedCarRepairshops { get; set; }
        public DbSet<CarRepairshopOpeningHour> CarRepairshopOpeningHours { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarRepairshop.Domain.Entities.CarRepairshop>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<ArchivedCarRepairshop>()
                .Property(x => x.CarRepairshopId)
                .ValueGeneratedNever();

            modelBuilder.Entity<ArchivedCarRepairshop>()
                .HasKey(x => x.CarRepairshopId);

            modelBuilder.Entity<CarRepairshopOpeningHour>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CarRepairshopOpeningHour>()
                .HasOne(x => x.CarRepairshops)
                .WithMany(x => x.CarRepairshopOpeningHours)
                .HasForeignKey("CarRepairshopId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasMany(x => x.Appointments)
                      .WithOne(x => x.Customer)
                      .HasForeignKey(x => x.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Customer)
                      .WithMany(x => x.Appointments)
                      .HasForeignKey(x => x.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Service)
                      .WithMany(x => x.Appointments)
                      .HasForeignKey(x => x.ServiceId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasMany(x => x.Appointments)
                      .WithOne(x => x.Service);

                entity.Property(x => x.Price)
                      .HasPrecision(18, 2);
            });
        }
    }
}
