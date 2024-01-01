using CarMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.IServices
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> Get(int? carId);
        Task AddCar(Car car);
        Task UpdateCar(Car car);
    }
}
