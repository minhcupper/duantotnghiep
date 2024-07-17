using AsigMent_c_5_MaiVanMinh_Pd09444.Model;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public userController(AppDbcontext dbcontext)
        {
            _context = dbcontext;
        }
        // GET: api/<foodsController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var dl = _context.users.ToList();
            return dl.ToList();
        }

        // GET: api/department/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var data = _context.users.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpPost]
        public ActionResult<Combo> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _context.users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/department/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/department/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.users.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.users.Remove(data);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
