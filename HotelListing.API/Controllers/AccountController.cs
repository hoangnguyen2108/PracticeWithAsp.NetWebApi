using HotelListing.API.Model.User;
using HotelListing.API.Service;
using HotelListing.API.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<ApiUser> _userManager;

        public AccountController(IAuthManager authManager,UserManager<ApiUser> userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register (UserDto userDto)
        {
            var result = await _authManager.Register(userDto);
            if (!result)
            {
                return BadRequest("Unsuccess");
            }
            return Ok("Success");
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login (LoginDto loginDto)
        {
            var result = await _authManager.Login(loginDto);
            if (!result)
            {
                return BadRequest("Unsuccess");
            }
            return Ok("Success");

        }

    }
}
