using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinasExerciciosController : ControllerBase
    {
        private readonly ApiContext _context;

        public RotinasExerciciosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/RotinasExercicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotinaExercicio>>> GetRotinaExercicio()
        {
            if (_context.RotinaExercicio == null)
            {
                return NotFound();
            }
            return await _context.RotinaExercicio.ToListAsync();
        }

        // GET: api/RotinasExercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RotinaExercicio>> GetRotinaExercicio(int id)
        {
            if (_context.RotinaExercicio == null)
            {
                return NotFound();
            }
            var rotinaExercicio = await _context.RotinaExercicio.FindAsync(id);

            if (rotinaExercicio == null)
            {
                return NotFound();
            }
            return rotinaExercicio;
        }

        // PUT: api/RotinasExercicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotinaExercicio(int id, RotinaExercicio rotinaExercicio)
        {
            if (id != rotinaExercicio.IdRotina)
            {
                return BadRequest();
            }

            _context.Entry(rotinaExercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotinaExercicioExists(id))
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

        // POST: api/RotinasExercicios
        [HttpPost]
        public async Task<ActionResult<RotinaExercicio>> PostRotinaExercicio(RotinaExercicio rotinaExercicio)
        {
            if (_context.RotinaExercicio == null)
            {
                return Problem("Entity set 'ApiContext.RotinaExercicio'  is null.");
            }
            _context.RotinaExercicio.Add(rotinaExercicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RotinaExercicioExists(rotinaExercicio.IdRotina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRotinaExercicio", new { id = rotinaExercicio.IdRotina }, rotinaExercicio);
        }

        // DELETE: api/RotinasExercicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotinaExercicio(int id)
        {
            if (_context.RotinaExercicio == null)
            {
                return NotFound();
            }
            var rotinaExercicio = await _context.RotinaExercicio.FindAsync(id);
            if (rotinaExercicio == null)
            {
                return NotFound();
            }

            _context.RotinaExercicio.Remove(rotinaExercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotinaExercicioExists(int id)
        {
            return (_context.RotinaExercicio?.Any(e => e.IdRotina == id)).GetValueOrDefault();
        }
    }
}
