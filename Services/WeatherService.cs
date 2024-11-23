using lr9.Models;
using System.Net.Http;
using System.Text.Json;

namespace lr9.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "53f521e54b4c286bfd07e0428890a8fd";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<JsonDocument>(content);
                    var root = weatherData.RootElement;

                    return new WeatherInfo
                    {
                        Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
                        Description = root.GetProperty("weather")[0].GetProperty("description").GetString(),
                        City = city
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}