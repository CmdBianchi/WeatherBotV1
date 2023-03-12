using Core;
using Core.Client;
using RestSharp;
using System.Runtime.CompilerServices;
using System.Web;
using WeatherBotV1.Services.OpenMeteo.Models;

namespace WeatherBotV1.Services.OpenMeteo
{
    public class OpenMeteoService : OpenMeteoServiceBase, IOpenMeteoService
    {
        public OpenMeteoService(IConfiguration config)
            : base(config)
        {

        }

        public async Task<CoordinatesResponse?> GetLocationDataAsync(string? filter = null)
        {
            try
            {
                var request = new RestRequest(
                    base.URLResorceBuilder(base._geocodingOpenMeteoURI, filter),
                    Method.Get
                )
                { RequestFormat = DataFormat.Json };

                return await base.AppRestClietnBuilder(base._baseGeocodingOpenMeteoURI).ExecuteRequestAsync<CoordinatesResponse>(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WetherTemperatureResponse?> GetWetherDataAsync(float latitude, float longitude)
        {
            try
            {
                var request = new RestRequest(
                    base.URLResorceBuilder(latitude, longitude),
                    Method.Get
                )
                { RequestFormat = DataFormat.Json };

                return await base.AppRestClietnBuilder(base._baseArchiveOpenMeteoURI).ExecuteRequestAsync<WetherTemperatureResponse>(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
