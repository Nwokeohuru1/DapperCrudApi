using DapperCrudApi.Interface;
using DapperCrudApi.Mdels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }



        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUsers()
        {
            var user = _userServices.AllUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("User")]
        public IActionResult GetUser(int id)
        {
            var user = _userServices.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateUser(users user)
        {
            var createdUser = _userServices.createUser(user);
            
            return StatusCode(StatusCodes.Status201Created, "User Created Successfully");
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult EdithUser(users user)
        {
            var editedUser = _userServices.updateUser(user);
            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteUser(int id)
        {
            var DeletedUser = _userServices.deleteUser(id);
            return Ok("User Deleted");
        }    
    }
}
