using HotelListing.API.Model.User;
using HotelListing.API.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace HotelListing.API.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<bool> Register(UserDto userDto)
        {
            var model = new ApiUser
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.EmailAddress,
                Email = userDto.EmailAddress
            };

            var result = await _userManager.CreateAsync(model, userDto.PassWord);
            if (result.Succeeded)
            {
                var update = await _userManager.AddToRoleAsync(model, "User");
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return false;
            }

            var password = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!password)
            {
                return false;
            }
            return true;
        }
    }
}
