using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Model.Hotel;

namespace HotelListing.API.Configurations
{
    public class MapperHotelConfig : Profile
    {
        public MapperHotelConfig()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, GetHotelDto>().ReverseMap();
            
               
        }
    }
}
