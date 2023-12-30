using ManageUserApi.Entities;
using ManageUserApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAllUser")]
        public ActionResult<List<User>> GetAllUser()
        {
           return _adminService.GetUsersList();
        }

        public IActionResult EnableUser(string id)
        {
            if(!_adminService.EnableUser(id))
            {
                return NotFound();
            }

            return Ok();
        }

        public IActionResult DisableUser(string id)
        {
            if (!_adminService.DisableUser(id))
            {
                return NotFound();
            }

            return Ok();
        }

        public IActionResult DeleteUser(string id)
        {
            try
            {
                _adminService.DeleteUser(id);
                return Ok();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}
