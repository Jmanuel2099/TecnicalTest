using Microsoft.AspNetCore.Mvc;
using TestModel.Implementation.SecurityModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserImplModel _userModel;

        public UserController() 
        {
            _userModel = new UserImplModel();
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userModel.RecordUserList());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userModel.RecordUserById(id));
        }
    }
}
