using WeatherBotV1.Services.OpenMeteo.Models;

namespace WeatherBotV1.Services.OpenMeteo
{
    public interface IOpenMeteoService
    {

        public Task<CoordinatesResponse?> GetLocationDataAsync(string? filter = null);

        public Task<WetherTemperatureResponse?> GetWetherDataAsync(float latitude, float longitude);

    }
}
