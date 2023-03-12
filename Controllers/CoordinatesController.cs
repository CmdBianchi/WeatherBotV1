using Microsoft.AspNetCore.Mvc;
using WeatherBotV1.Services.OpenMeteo;
using WeatherBotV1.Services.OpenMeteo.Models;

namespace WeatherBotV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : Controller
    {

        public CoordinatesController(IOpenMeteoService openMeteroService)
        {
            this.OpenMeteroService = openMeteroService;
        }

        public IOpenMeteoService OpenMeteroService { get; set; }

        [HttpGet(Name = "GetLocationData")]
        public async Task<CoordinatesResponse?> GetAsync(string? filter = null)
        {
            return await this.OpenMeteroService.GetLocationDataAsync(filter);
        }

    }
}
