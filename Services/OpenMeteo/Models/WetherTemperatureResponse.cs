using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WeatherBotV1.Services.OpenMeteo.Models.Shared;

namespace WeatherBotV1.Services.OpenMeteo.Models
{
    public class WetherTemperatureResponse
    {

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string? TimeZoneAbbreviation { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public decimal UtcOffsetSeconds { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("daily")]
        public DailyTemperature? DailyTemperature { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyUnits? DailyUnits { get; set; }

        [JsonPropertyName("hourly")]
        public HourlyTemperature? HourlyTemperature { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits? HourlyUnits { get; set; }

    }
}
