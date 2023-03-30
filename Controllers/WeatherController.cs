using Attorney.Manager.Repository.Context;
using AutoMapper;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WeatherBotV1.Services.OpenMeteo;
using WeatherBotV1.Services.OpenMeteo.Models;
using WeatherMachineLearning;

namespace WeatherBotV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        public WeatherController(IOpenMeteoService openMeteroService, IMapper mapper)
        {
            this.OpenMeteroService = openMeteroService;
            this.Mapper = mapper;
        }

        public IMapper Mapper { get; set; }

        public IOpenMeteoService OpenMeteroService { get; set; }

        [HttpGet("GetWetherData")]
        public async Task<IActionResult> Get(float latitude, float longitude)
        {
            var response = await this.OpenMeteroService.GetWetherDataAsync(latitude, longitude);

            if (response is null || response.Equals(new WetherTemperatureResponse()))
                return base.NotFound();

            return this.Ok(response);
        }

        [HttpGet("Predition")]
        public async Task<IActionResult> Get()
        {
            var weatherPrediction = new WeatherPrediction();
            weatherPrediction.Prediction(this.Mapper);
            return this.Ok();
        }

        [HttpPost("PopulateWetherData")]
        public async Task<IActionResult> Post(float latitude, float longitude)
        {
            var response = await this.OpenMeteroService.GetWetherDataAsync(latitude, longitude);

            if (response is null || response.Equals(new WetherTemperatureResponse()))
                return base.NotFound();

            var temperatures = new List<Temperature>();
            var dbContext = new DataContext();
            var city = await dbContext.City.FirstOrDefaultAsync() ?? null;
            for (int i = 0; i < response?.HourlyTemperature?.Temperature2mMax?.Count() - 1; i++)
            {
                city.Temperature.Add(new Temperature()
                {
                    DegreeTemperature = Convert.ToDouble(response?.HourlyTemperature?.Temperature2mMax?.ElementAt(i)),
                    Time = Convert.ToDateTime(response?.HourlyTemperature?.Time?.ElementAt(i))
                });
                await dbContext.SaveChangesAsync();
            }

            return this.Ok(city);
        }
    }
}