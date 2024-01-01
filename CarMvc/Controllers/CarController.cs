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

        [HttpGet] // Dla wyświetlania wszystkich samochodów
        public async Task<IActionResult> Index()
        {
            var cars = await _service.Get(null);
            return View(cars);
        }

        [HttpGet("{id}")] // Dla wyświetlania samochodu o konkretnym ID
        public async Task<IActionResult> Index(int id)
        {
            var cars = await _service.Get(id);
            return View(cars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Car()); // Zwraca widok z pustym modelem Car
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCar(car);
                return RedirectToAction("Index"); // Przekierowanie do listy samochodów po pomyślnym dodaniu
            }
            return View(car); // Zwróć ten sam widok w przypadku błędów walidacji
        }

        // Metoda GET do wyświetlenia formularza edycji
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cars = await _service.Get(id);
            var car = cars.FirstOrDefault(); // Zakładamy, że Get zwraca kolekcję
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // Metoda POST do przetwarzania formularza edycji
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
    }
}
