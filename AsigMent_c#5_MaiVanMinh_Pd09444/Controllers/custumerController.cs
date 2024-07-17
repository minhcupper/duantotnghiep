using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class custumerController : ControllerBase
    {
        // GET: api/<foodsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<foodsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<foodsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<foodsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<foodsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
