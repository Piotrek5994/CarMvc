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

            //Configuration for Car
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Owner)
                      .WithOne(o => o.car)
                      .HasForeignKey<Car>(c => c.OrgId);
            });
            // Configuration for Organization
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(o => o.Id);
                
                entity.HasOne(a => a.Address)
                      .WithOne(o => o.Organization)
                      .HasForeignKey<Address>(a => a.OrgId);
            });
            // Configuration for Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(o => o.Id);
            });

            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, Model = "Octavia", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Skoda", RegistrationNumber = "ABC123", Priority = Priority.High, OrgId = 1 },
                new Car() { Id = 2, Model = "A3", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Audi", RegistrationNumber = "DEF456", Priority = Priority.High, OrgId = 2 }
            );

            modelBuilder.Entity<Organization>().HasData(
                new Organization() { Id = 1, Name = "Organizacja A", NIP = "1234567890", AdrId = 1 },
                new Organization() { Id = 2, Name = "Organizacja B", NIP = "0987654321", AdrId = 2 }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, Street = "Ulica A", Number = 1, City = "Miasto A", State = "Stan A", Country = "Kraj A", OrgId = 1 },
                new Address() { Id = 2, Street = "Ulica B", Number = 2, City = "Miasto B", State = "Stan B", Country = "Kraj B", OrgId = 2 }
            );
        }
    }
}
