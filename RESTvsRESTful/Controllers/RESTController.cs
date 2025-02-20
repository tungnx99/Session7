using Microsoft.AspNetCore.Mvc;

namespace RESTvsRESTful.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RESTController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser([FromQuery] int id)
        {
            return Ok(new UserModel());
        }

        [HttpGet]
        public IActionResult SearchUser([FromQuery] UserModel model)
        {
            return Ok(new List<UserModel>() { model, model, model });
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            Response.StatusCode = 201;
            return Ok(user);
        }

        [HttpPost]
        public IActionResult UpdateUser([FromQuery] int id, [FromBody] UserModel user)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            return Ok();
        }
    }
}
