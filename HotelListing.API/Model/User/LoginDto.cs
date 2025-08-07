using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Model.User
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
