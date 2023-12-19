using CarMvc.Models;
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
            modelBuilder.Entity<Car>().HasData(
            new Car() { Id = 1, Model = "Octavia", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Skoda", RegistrationNumber = "ABC123", Priority = Priority.High, Owner = "Jan Nowak" },
            new Car() { Id = 2, Model = "A3", Capacity = 1.4, Motor = "Benzyna", Power = 100, Producer = "Audi", RegistrationNumber = "DEF456", Priority = Priority.High, Owner = "Anna Kowalska" }
            );
        }
    }
}
