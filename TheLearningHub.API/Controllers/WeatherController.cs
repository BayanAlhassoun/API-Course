using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheLearningHub.core.DTO;

namespace TheLearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        [Route("GetWeatherByCity/{cityName}")]
        public async Task<WeatherResult> GetWeatherByCityName(string cityName)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=18c3325631443ebfcf956eeeeaf71dcf&units=metric");
                var resultAsString = await response.Content.ReadAsStringAsync();
                var finalResult = JsonConvert.DeserializeObject<WeatherResult>(resultAsString);
                return finalResult;
                
            }
        }
    }
}
