using CarMvc;
using CarMvc.Models;
using Core.IRepositories;
using Infrastructure.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CarRepositories : ICarRepositories
    {
        private readonly SqlDbContext _context;

        public CarRepositories(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Car
                         .Include(c => c.Owner)
                         .ThenInclude(c => c.Address)
                         .ToListAsync();
        }
        public async Task AddCar(Car car)
        {
            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();
        }
    }
}
