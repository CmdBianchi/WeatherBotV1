using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherBotV1.Services.OpenMeteo.Models.Shared
{
    public class HourlyTemperature
    {
        [JsonPropertyName("temperature_2m")]
        public IEnumerable<double?>? Temperature2mMax { get; set; }

        [JsonPropertyName("time")]
        public IEnumerable<string?>? Time { get; set; }
    }
}
