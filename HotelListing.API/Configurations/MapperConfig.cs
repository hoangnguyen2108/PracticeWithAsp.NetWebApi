using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Model.Country;
using HotelListing.API.Model.Hotel;
namespace HotelListing.API.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountry>().ReverseMap();
            CreateMap<Country, GetCountry>().ReverseMap();
            CreateMap<Country, GetCountryDetail>()
                .ForMember(dest => dest.Hotels, opt => opt.MapFrom(src => src.HotelList));
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Country, UpdateContryDto>().ReverseMap();
        }
    }
}
