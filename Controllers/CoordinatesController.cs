using Attorney.Manager.Repository.Context;
using AutoMapper;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using WeatherBotV1.Services.OpenMeteo;
using WeatherBotV1.Services.OpenMeteo.Models;

namespace WeatherBotV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : Controller
    {

        public CoordinatesController(IOpenMeteoService openMeteroService, IMapper mapper)
        {
            this.OpenMeteroService = openMeteroService;
            this.Mapper= mapper;
        }

        public IOpenMeteoService OpenMeteroService { get; set; }
        public IMapper Mapper { get; set; }


        [HttpGet(Name = "GetLocationData")]
        public async Task<IActionResult> Get(string? filter = null)
        {
            var response = await this.OpenMeteroService.GetLocationDataAsync(filter);

            if (response is null || response.Equals(new CoordinatesResponse()))
                return base.NotFound();

            return base.Ok(response);
        }

        [HttpPost(Name = "PostCityData")]
        public async Task<IActionResult> Post(string? filter = null)
        {
            var response = await this.OpenMeteroService.GetLocationDataAsync(filter);

            if (response is null || response.Equals(new CoordinatesResponse()))
                return base.NotFound();
            try
            {
                var cities = this.Mapper.Map<List<City>>(response.Results.ToList());
                using (var dbContext = new DataContext())
                {
                    await dbContext.City.AddAsync(cities.FirstOrDefault());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                return base.BadRequest(ex);
            }

           return base.Ok(response);
        }

    }
}
