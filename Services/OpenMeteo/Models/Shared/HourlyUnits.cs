using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherBotV1.Services.OpenMeteo.Models.Shared
{

    public class HourlyUnits
    {

        [JsonPropertyName("temperature_2m")]
        public string? Temperature2mMaxType { get; set; }

        [JsonPropertyName("time")]
        public string? TimeType { get; set; }

    }
}
