using CarMvc.Models;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMvc
{
    public class SqlDbContext : DbContext
    {
        DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=C:\\Users\\piotr\\Desktop\\Projekty C#\\CarMvc\\car.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>()
                .HasOne(e => e.Owner)
                .WithOne(e => e.car)
                .HasForeignKey<Organization>(e => e.Id);

            modelBuilder.Entity<Organization>()
                .HasOne(e=> e.car)
                .WithOne(e => e.Owner)
                .HasForeignKey<Car>(e => e.Id);
                
            modelBuilder.Entity<Address>()
                .HasOne(e => e.Organization)
                .WithOne(e => e.Address)
                .HasForeignKey<Organization>(e => e.Id);

            modelBuilder.Entity<Car>().HasData(
            new Car() { Id = 1, Model = "Octavia", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Skoda", RegistrationNumber = "ABC123", Priority = Priority.High},
            new Car() { Id = 2, Model = "A3", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Audi", RegistrationNumber = "DEF456", Priority = Priority.High}
            );
        }
    }
}
