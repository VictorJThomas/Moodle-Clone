using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moodle_Clone.Domain.Interfaces;
using static Moodle_Clone.Domain.DTOs.UsersDTO;

namespace Moodle_Clone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController (IUsersService userService) 
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserDTO>> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            try
            {
                var (isAuthenticated, token) = await _userService.LoginUser(loginUserDTO);
                if (isAuthenticated)
                {
                    return Ok(new LoginUserDTO { Token = token });
                }
                else
                {
                    return Unauthorized("Invalid login credentials.");
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            try
            {
                await _userService.RegisterUser(registerUserDTO);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
