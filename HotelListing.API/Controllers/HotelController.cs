using HotelListing.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        
        private List<Hotel> Hotels = new List<Hotel> { new Hotel
        {
            Id = 1,
            Name = "Hotel1",
            Address = "Address1",
            Rating = 3.1
        }, new Hotel
        {
            Id =2,
            Name = "Hotel2",
            Address = "Address2",
            Rating = 4.2
        }};
        //  Sumamary
        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(Hotels);
        }
        // Index
        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var program = Hotels.FirstOrDefault(c => c.Id == id);

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
        public ActionResult<Hotel> Post([FromBody] Hotel hotel)
        {
            if (Hotels.Any(c => c.Id == hotel.Id))
            {
                Console.WriteLine("Duplicate Hotel");
                return BadRequest("Hotel Alredy Exit");
            }
            Hotels.Add(hotel);
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public  ActionResult<Hotel> Put(int id, [FromBody] Hotel hotel)
        {
            var product =  Hotels.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                Console.WriteLine("No Hotel");
                return NotFound();
            }

            product.Name = hotel.Name;
            product.Address = hotel.Address;
            product.Rating = hotel.Rating;

            return CreatedAtAction(nameof(Get),new {id = hotel.Id}, hotel);
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = Hotels.FirstOrDefault(c => c.Id==id);
            if (product == null)
            {
                return BadRequest("Not Found Hotel");
            }

            Hotels.Remove(product);
            return NoContent();
        }
    }
}
