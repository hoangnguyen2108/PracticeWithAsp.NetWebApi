using HotelListing.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        
        private ApplicationDbContext _context;
        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }
        //  Sumamary
        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            var model = _context.Hotels.Select(c => new Hotel
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Rating = c.Rating,
                CountryId = c.CountryId
            }).ToList();
            return Ok(model);
        }
        // Index
        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            var program = await _context.Hotels.FindAsync(id);

            if (program == null)
            {
                Console.WriteLine("No Hotel Under That ID");
                return NotFound();
            }
            return Ok(program);
        }

        // Create
        // POST api/<HotelController>
        [HttpPost]
        public async Task<ActionResult<Hotel>> Post([FromBody] Hotel hotel)
        {
            var product = await _context.Hotels.AnyAsync(c => c.Id == hotel.Id);
            if (product == true)
            {
                Console.WriteLine("Duplicate Hotel");
                return BadRequest("Hotel Alredy Exit");
            }
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public  async Task<ActionResult<Hotel>> Put(int id, [FromBody] Hotel hotel)
        {
            var product = await _context.Hotels.FindAsync(id);
            if (product == null)
            {
                Console.WriteLine("No Hotel");
                return NotFound();
            }

            product.Name = hotel.Name;
            product.Address = hotel.Address;
            product.Rating = hotel.Rating;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),new {id = hotel.Id}, hotel);
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _context.Hotels.FindAsync(id);
            if (product == null)
            {
                return BadRequest("Not Found Hotel");
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
