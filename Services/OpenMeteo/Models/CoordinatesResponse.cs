using System.Text.Json.Serialization;
using WeatherBotV1.Services.OpenMeteo.Models.Shared;

namespace WeatherBotV1.Services.OpenMeteo.Models
{
    public class CoordinatesResponse
    {

        [JsonPropertyName("results")]
        public ICollection<CoordinatesResult> Results { get; set; } = new List<CoordinatesResult>();

        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

    }
}
