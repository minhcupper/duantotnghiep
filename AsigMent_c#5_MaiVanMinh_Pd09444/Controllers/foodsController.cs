using AsigMent_c_5_MaiVanMinh_Pd09444.Model;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foodsController : ControllerBase
    {
        // GET: api/<foodsController>
        private readonly AppDbcontext _context;
        public foodsController(AppDbcontext dbcontext)
        {
            _context = dbcontext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<food>> Get()
        {
            var dl = _context.foods.ToList();
            return dl.ToList();
        }

        // GET: api/department/5
        [HttpGet("{id}")]
        public ActionResult<food> Get(int id)
        {
            var data = _context.foods.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

       /* [HttpGet("{id}")]
        public ActionResult<Combo> Getcombo(int comboid)
        {
            var data = _context.combos.Find(comboid);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }*/


        [HttpPost]
        public ActionResult<food> Post([FromBody] food food)
        {
            if (food == null)
            {
                return BadRequest();
            }

            _context.foods.Add(food);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = food.Id }, food);
        }

        // PUT: api/department/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/department/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.foods.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.foods.Remove(data);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
