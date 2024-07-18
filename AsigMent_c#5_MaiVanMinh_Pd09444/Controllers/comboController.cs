using AsigMent_c_5_MaiVanMinh_Pd09444.Model;
using Data.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comboController : ControllerBase
    {
       private readonly AppDbcontext _context; 
      public comboController( AppDbcontext dbcontext)
        {
            _context = dbcontext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Combo>> Get()
        {
            //thay doi vi du mau
            var dl = _context.combos.ToList();
            return dl.ToList();
        }
       //thinh thay doi
        // GET: api/department/5
        [HttpGet("{id}")]
        public ActionResult<Combo> Get(int id)
        {
           
            var data = _context.combos.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpPost]
        public ActionResult<Combo> Post([FromBody] Combo combo)
        {
            // tung thay doi
            if (combo == null)
            {
                return BadRequest("Combo cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.combos.Add(combo);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (you can use a logging framework or just write to the console)
                Console.WriteLine(ex.InnerException?.Message);

                // Return a meaningful error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the combo.");
            }

            return CreatedAtAction(nameof(Get), new { id = combo.id }, combo);
        }
        // PUT: api/department/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Combo combo)
        {
            if (id != combo.id)
            {
                return BadRequest();
            }

            _context.Entry(combo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComboExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ComboExists(int id)
        {
            return _context.combos.Any(e => e.id == id);
        }

        // DELETE: api/department/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.combos.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.combos.Remove(data);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
