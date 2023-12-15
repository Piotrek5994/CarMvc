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

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
