using HotelListing.API.Model.User;

namespace HotelListing.API.Service
{
    public interface IAuthManager
    {
        Task<bool> Login(LoginDto loginDto);
        Task<bool> Register(UserDto userDto);
    }
}