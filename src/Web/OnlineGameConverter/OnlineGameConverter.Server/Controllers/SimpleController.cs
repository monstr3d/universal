using IronPython.Runtime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace OnlineGameConverter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        // GET: api/<SimpleController>
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // GET api/<SimpleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SimpleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SimpleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SimpleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
