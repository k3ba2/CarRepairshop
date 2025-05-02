using CarRepairshop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRepairshop.Infrastructure.Persistance
{
    public class CarRepairshopDbContext : IdentityDbContext<IdentityUser>
    {
        public CarRepairshopDbContext(DbContextOptions<CarRepairshopDbContext> options) : base(options)
        {
        }

        public DbSet<CarRepairshop.Domain.Entities.CarRepairshop> CarRepairshops { get; set; }
        public DbSet<ArchivedCarRepairshop> ArchivedCarRepairshops { get; set; }
        public DbSet<CarRepairshopOpeningHour> CarRepairshopOpeningHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
