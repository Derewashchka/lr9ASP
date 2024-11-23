using Microsoft.AspNetCore.Mvc;
using lr9.Models;
using lr9.Services;

namespace lr9.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Laptop", Price = 999.99m },
                new Product { ID = 2, Name = "Smartphone", Price = 499.99m },
                new Product { ID = 3, Name = "Tablet", Price = 299.99m }
            };

            ViewBag.Products = products;
            return View();
        }
    }
}