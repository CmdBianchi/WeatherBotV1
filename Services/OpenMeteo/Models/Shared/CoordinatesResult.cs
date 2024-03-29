﻿using System.Text.Json.Serialization;

namespace WeatherBotV1.Services.OpenMeteo.Models.Shared
{
    public class CoordinatesResult
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("feature_code")]
        public string? FeatureCode { get; set; }

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// This properties represents the local public administration from the region
        /// </summary>
        #region " Region Administration "

        [JsonPropertyName("admin1_id")]
        public int Admin1Id { get; set; }

        [JsonPropertyName("admin1")]
        public string? Admin1 { get; set; }

        [JsonPropertyName("admin2_id")]
        public int Admin2Id { get; set; }

        [JsonPropertyName("Admin2")]
        public string? Admin2 { get; set; }

        [JsonPropertyName("admin3_id")]
        public int Admin3Id { get; set; }

        [JsonPropertyName("Admin3")]
        public string? Admin3 { get; set; }

        #endregion

    }
}
