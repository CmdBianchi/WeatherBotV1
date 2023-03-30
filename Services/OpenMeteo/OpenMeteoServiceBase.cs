using Core.Client;
using System.Web;

namespace WeatherBotV1.Services.OpenMeteo
{
    public class OpenMeteoServiceBase
    {

        private protected readonly string? _archiveOpenMeteoURI = string.Empty;
        private protected readonly string? _geocodingOpenMeteoURI = string.Empty;
        private protected readonly string? _baseArchiveOpenMeteoURI = string.Empty;
        private protected readonly string? _baseGeocodingOpenMeteoURI = string.Empty;

        private protected OpenMeteoServiceBase(IConfiguration config)
        {
            this._baseArchiveOpenMeteoURI = config?.GetValue<string>("OpenMeteoURIs:BaseArchiveOpenMeteoURI");
            this._archiveOpenMeteoURI = config?.GetValue<string>("OpenMeteoURIs:ArchiveOpenMeteoURI");
            this._baseGeocodingOpenMeteoURI = config?.GetValue<string>("OpenMeteoURIs:BaseGeocodingMeteoURI");
            this._geocodingOpenMeteoURI = config?.GetValue<string>("OpenMeteoURIs:GeocodingOpenMeteo");
        }

        private protected AppRestClient AppRestClietnBuilder(string? baseURL)
           => new AppRestClient(@$"{baseURL}");

        private protected string URLResorceBuilder(float latitude, float longitude)
        {
            var uri = new UriBuilder(@$"https://archive-api.open-meteo.com/v1/archive?latitude={latitude.ToString().Replace(',', '.')}&longitude={longitude.ToString().Replace(',', '.')}&start_date=2000-01-01&end_date={DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd")}&hourly=temperature_2m&daily=temperature_2m_max,temperature_2m_min&timezone=America%2FSao_Paulo");

            return uri.ToString();
        }

        private protected string URLResorceBuilder(string? baseURL, string? filter = null)
        {
            var uri = new UriBuilder(baseURL ?? "");
            var query = HttpUtility.ParseQueryString(uri.Query);
            query["name"] = filter;

            uri.Query = query.ToString();

            return uri.ToString();
        }

    }
}
