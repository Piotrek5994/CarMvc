using CarMvc.Models;
using Infrastructure.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarMvc.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _service.Get(null);
            return View(cars);
        }

        [HttpGet("Car/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var cars = await _service.Get(id);
            return View(cars);
        }

        [HttpGet("Car/Add")]
        public IActionResult Add()
        {
            return View(new Car());
        }

        [HttpPost("Car/Add")]
        public async Task<IActionResult> Add(Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET method to display the edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cars = await _service.Get(id);
            var car = cars.FirstOrDefault();
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST method for processing the edit form
        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCar(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Car/View/{id}")]
        public async Task<IActionResult> View(int id)
        {
            var car = await _service.Get(id);
            if (car == null || !car.Any())
            {
                return NotFound();
            }

            return View(car.FirstOrDefault());
        }
    }
}
