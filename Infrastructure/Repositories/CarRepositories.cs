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

        public async Task<IEnumerable<Car>> Get(int? carId)
        {
            var query = _context.Car
                         .Include(c => c.Owner)
                         .ThenInclude(c => c.Address)
                         .AsQueryable();
            if(carId != null)
            {
                query = query.Where(x => x.Id == carId);
            }

            return await query.ToListAsync();
        }
        public async Task AddCar(Car car)
        {
            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCar(Car car)
        {
            var existingCar = await _context.Car.FindAsync(car.Id);
            if (existingCar != null)
            {
                _context.Entry(existingCar).CurrentValues.SetValues(car);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Samochód o ID {car.Id} nie został znaleziony.");
            }
        }
        public async Task DeleteCar(int carId)
        {
            var carToDelete = await _context.Car.FindAsync(carId);
            if (carToDelete != null)
            {
                _context.Car.Remove(carToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Samochód o ID {carId} nie został znaleziony.");
            }
        }
    }
}
