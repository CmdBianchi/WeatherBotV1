using Microsoft.AspNetCore.Mvc;
using WeatherBotV1.Services.OpenMeteo;
using WeatherBotV1.Services.OpenMeteo.Models;

namespace WeatherBotV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        public WeatherController(IOpenMeteoService openMeteroService)
        {
            this.OpenMeteroService = openMeteroService;
        }

        public IOpenMeteoService OpenMeteroService { get; set; }

        [HttpGet(Name = "GetWetherData")]
        public async Task<WetherTemperatureResponse?> GetAsync(float latitude, float longitude)
        {
            return await this.OpenMeteroService.GetWetherDataAsync(latitude, longitude);
        }

    }
}