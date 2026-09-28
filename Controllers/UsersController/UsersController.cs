using FileHub.Database.Classes;
using Microsoft.AspNetCore.Mvc;

namespace FileHub.Controllers.UsersController
{
    [Route("user")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        public UsersController(UsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult GetAllUser()
        {
            return Ok(_usersService.GetAllUsers());
        }

        [HttpGet("{name}")]
        public ActionResult<Users?> GetUser(string name)
        {
            var user = _usersService.GetUser(name);

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult NewUser([FromBody] string name)
        {
            _usersService.NewUser(name);
            return Ok();
        }
    }
}
