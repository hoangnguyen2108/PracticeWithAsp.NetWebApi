using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Model.Country;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Index
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var model = _context.Countries.Select(c => new CreateCountry
            {
                Name = c.Name,
                ShortName = c.ShortName,
            }).ToList();
            return Ok(model);
        }

        
        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // Edit
        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, CreateCountry country)
        {
            var product = await _context.Countries.FindAsync(id);
            if (product == null)
            {
                return BadRequest("No Country available");
            }

            product.Name = country.Name;
            product.ShortName = country.ShortName;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCountry), new {id = product.Id}, product);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry country)
        {
            var product = new Country
            {
                Name = country.Name,
                ShortName = country.ShortName,
            };
            _context.Countries.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = product.Id }, product);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var product = await _context.Countries.FindAsync(id);

            if(product == null)
            {
                return BadRequest("No Country");
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCountry), new { id = product.Id }, product);
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
