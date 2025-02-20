using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTvsRESTful.Controllers
{
    [Route("api/[controller]/User")]
    [ApiController]
    public class RESTfulController : ControllerBase
    {
        // GET api/<RESTfulController>
        [HttpGet]
        public IActionResult Get([FromQuery] int? id, [FromQuery] UserModel model)
        {
            return Ok(new List<UserModel>() { model, model, model });
        }

        // RESTful can include POST & PUT to only Method (Insert/Update)
        // For example
        //// POST api/<RESTfulController>
        //[HttpPost]
        //public IActionResult Post([FromQuery] int? id, [FromBody] UserModel user)
        //{
        //    if (!id.HasValue)
        //    {
        //        Response.StatusCode = 201;
        //    }
        //    return Ok(user);
        //}

        // POST api/<RESTfulController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            Response.StatusCode = 201;
            return Ok(user);
        }

        // PUT api/<RESTfulController>/5
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] UserModel user)
        {
            return Ok(user);
        }

        // PATCH api/<RESTfulController>/5
        [HttpPatch]
        public IActionResult PATCH([FromQuery] int id, [FromBody] UserModel user)
        {
            return Ok(user);
        }

        // DELETE api/<RESTfulController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            return Ok();
        }
    }
}
