using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using WeatherBotV1.Services.OpenMeteo.Models.Shared;
using Data.Domain;
using static WeatherMachineLearning.WeatherPrediction;

namespace WeatherBotV1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // City
            this.CreateMap<CoordinatesResult, City>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MeteoWeatherId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ControlName1, opt => opt.MapFrom(src => src.Admin1))
                .ForMember(dest => dest.ControlName2, opt => opt.MapFrom(src => src.Admin2))
                .ForMember(dest => dest.ControlName3, opt => opt.MapFrom(src => src.Admin3))
                .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.Timezone))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Temperature, opt => opt.Ignore())
                .ReverseMap();

            // Temperature
            this.CreateMap<TemperatureHistogram, Temperature>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.DegreeTemperature, opt => opt.MapFrom(src => src.DegreeTemperature))
                .ReverseMap();
        }
    }
}
