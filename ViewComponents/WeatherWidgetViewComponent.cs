using Microsoft.AspNetCore.Mvc;
using lr9.Models;
using lr9.Services;

namespace lr9.ViewComponents
{
    public class WeatherWidgetViewComponent : ViewComponent
    {
        private readonly WeatherService _weatherService;

        public WeatherWidgetViewComponent(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string city)
        {
            var weatherInfo = await _weatherService.GetWeatherAsync(city);
            return View(weatherInfo);
        }
    }
}