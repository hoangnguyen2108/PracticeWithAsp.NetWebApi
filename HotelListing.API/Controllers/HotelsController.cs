using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using AutoMapper;
using HotelListing.API.Model.Hotel;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotel = await _context.Hotels.ToListAsync();
            var update = _mapper.Map<List<HotelDto>>(hotel);
            return Ok(update);
        }
        // Find single Hotel
        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return BadRequest();
            }
             _mapper.Map<GetHotelDto>(hotel);

            return CreatedAtAction(nameof(GetHotels), new Hotel { Id = hotel.Id}, hotel);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
          

            return NoContent();
        }
        // Create Hotel
        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostHotel(HotelDto producthotel)
        {           
            var product = _mapper.Map<Hotel>(producthotel);
            _context.Hotels.Add(product);
            await _context.SaveChangesAsync();
            var update = _mapper.Map<HotelDto>(product);
            return Ok(update);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var listhotel = await _context.Hotels.FindAsync(id);
            if (listhotel == null)
            {
                return BadRequest();
            }     
            _context.Remove(listhotel);
            await _context.SaveChangesAsync();
            var update = _mapper.Map<HotelDto>(listhotel);
            return Ok(update);
            


        }

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
