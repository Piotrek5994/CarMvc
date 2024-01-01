﻿using CarMvc.Models;
using Core.IRepositories;
using Infrastructure.EntityModel;
using Infrastructure.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepositories _repositories;

        public CarService(ICarRepositories repositories)
        {
            _repositories = repositories;
        }
        public async Task<IEnumerable<Car>> Get(int? carId)
        {
            return await _repositories.Get(carId);
        }
    }
}
