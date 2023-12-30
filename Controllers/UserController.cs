using ManageUserApi.DTOs;
using ManageUserApi.Entities;
using ManageUserApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            Role role = _userService.Login(login);

            if(role == null)
            {
                return NotFound();
            }

            return Ok(role.RoleId);
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto register)
        {
            try
            {
                _userService.Register(register);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
