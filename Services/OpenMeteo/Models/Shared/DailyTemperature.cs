using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherBotV1.Services.OpenMeteo.Models.Shared
{
    public class DailyTemperature
    {

        [JsonPropertyName("temperature_2m_max")]
        public IEnumerable<double?>? Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public IEnumerable<double?>? Temperature2mMin { get; set; }

        [JsonPropertyName("time")]
        public IEnumerable<string?>? Time { get; set; }

    }
}
