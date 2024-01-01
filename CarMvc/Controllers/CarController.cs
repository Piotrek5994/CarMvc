using CarMvc.Models;
using Infrastructure.EntityModel;
using Infrastructure.Services;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int? id)
        {
            var cars = await _service.Get(id);
            return View(cars);
        }
        [HttpGet]
        //Służy do stworzenia vidoku przy dodawaniu
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        //Służy do dodania użytkownika
        public async Task<IActionResult> Add(Car car)
        {
            return RedirectToAction("Add");
        }
    }
}
