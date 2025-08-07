using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Model.User
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string PassWord { get; set; }
    }
}
