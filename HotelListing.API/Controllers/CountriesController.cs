using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Model.Country;
using AutoMapper;
using HotelListing.API.Service;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _service;
        private readonly ApplicationDbContext _context;
       
        private readonly IMapper _mapper;

        public CountriesController(ICountriesService service,ApplicationDbContext context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }
        // Index
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var model = await _service.GetCountry();
            return Ok(model);
        }

        
        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetail>> GetCountry(int id)
        {
            var country = await _service.GetSingleCountry(id);     
            return Ok(country);
        }

        // Edit
        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateContryDto country)
        {
            var product = await _service.EditCountry(id, country);
            return CreatedAtAction(nameof(GetCountry), new {id = product.Id}, product);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCountry(CreateCountry country)
        {
            var product = await _service.CreateCountry(country);
            return CreatedAtAction("GetCountry", new { id = product.Id }, product);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var product = await _service.DeleteCountry(id);
            return Ok(product);
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
