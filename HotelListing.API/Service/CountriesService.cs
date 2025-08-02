using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.Model.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Service
{
    public class CountriesService : ICountriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CountriesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCountry>> GetCountry()
        {
            var model = await _context.Countries.ToListAsync();
            var record = _mapper.Map<List<GetCountry>>(model);
            return record;
        }


        public async Task<GetCountryDetail> GetSingleCountry(int id)
        {
            var country = await _context.Countries.Include(c => c.HotelList)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                Console.WriteLine("Did not find the country");
                return null;
            }

            var record = _mapper.Map<GetCountryDetail>(country);

            return record;
        }

        public async Task<GetCountryDetail> EditCountry(int id, UpdateContryDto country)
        {
            var product = await _context.Countries.FindAsync(id);
            if (product == null)
            {
                Console.WriteLine("No Country Found");
                return null;
            }
            _mapper.Map(country, product);
            await _context.SaveChangesAsync();
            var updated = _mapper.Map<GetCountryDetail>(product);
            return updated;
        }

        public async Task<GetCountryDetail> CreateCountry(CreateCountry country)
        {
            var product = _mapper.Map<Country>(country);
            _context.Countries.Add(product);
            await _context.SaveChangesAsync();

            var updated = _mapper.Map<GetCountryDetail>(product);
            return updated;
        }

        public async Task<GetCountryDetail> DeleteCountry(int id)
        {
            var product = await _context.Countries.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
            var updated = _mapper.Map<GetCountryDetail>(product);
            return updated;
        }

    }
}
       
       
    
    

