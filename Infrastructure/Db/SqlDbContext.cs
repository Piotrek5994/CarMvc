using CarMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CarMvc
{
    public class SqlDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        DbSet<Car> Cars { get; set; }

        public SqlDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_configuration.GetConnectionString("LocalDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
