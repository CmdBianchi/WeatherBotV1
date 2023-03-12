using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherBotV1.Services.OpenMeteo.Models.Shared
{
    public class DailyUnits
    {

        [JsonPropertyName("temperature_2m_max")]
        public string? Temperature2mMaxType { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string? Temperature2mMinType { get; set; }

        [JsonPropertyName("time")]
        public string? TimeType { get; set; }

    }
}
