using HotelListing.API.Model.Country;

namespace HotelListing.API.Service
{
    public interface ICountriesService
    {
        Task<GetCountryDetail> CreateCountry(CreateCountry country);
        Task<GetCountryDetail> DeleteCountry(int id);
        Task<GetCountryDetail> EditCountry(int id, UpdateContryDto country);
        Task<List<GetCountry>> GetCountry();
        Task<GetCountryDetail> GetSingleCountry(int id);
    }
}