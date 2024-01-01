using CarMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface ICarRepositories
    {
        Task<IEnumerable<Car>> GetAll();
        Task AddCar(Car car);
    }
}
