using LayOutView.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayOutView.Controllers
{

    public class HomeController : Controller
    {
        private List<CityWeather> cities = new List<CityWeather>() {
    new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

    new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

    new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
   };
        [Route("/")]
        public IActionResult Index()
        {
            
            return View(cities);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult City(string? cityCode)
        {
            if(cityCode == null)
            {
                return BadRequest("city name can't be null");
            }
            var filter = cities.First(item => item.CityUniqueCode == cityCode);
            if (filter == null)
            {
                return Content("the city doesn't exist");
                
            }
            return View(filter);
        }
    }
}