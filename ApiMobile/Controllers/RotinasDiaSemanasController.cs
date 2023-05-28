using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinasDiaSemanasController : ControllerBase
    {
        private readonly ApiContext _context;

        public RotinasDiaSemanasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/RotinasDiaSemanas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotinaDiaSemana>>> GetRotinaDiaSemana()
        {
            if (_context.RotinaDiaSemana == null)
            {
                return NotFound();
            }
            return await _context.RotinaDiaSemana.ToListAsync();
        }

        // GET: api/RotinasDiaSemanas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RotinaDiaSemana>> GetRotinaDiaSemana(int id)
        {
            if (_context.RotinaDiaSemana == null)
            {
                return NotFound();
            }
            var rotinaDiaSemana = await _context.RotinaDiaSemana.FindAsync(id);

            if (rotinaDiaSemana == null)
            {
                return NotFound();
            }
            return rotinaDiaSemana;
        }

        // PUT: api/RotinasDiaSemanas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotinaDiaSemana(int id, RotinaDiaSemana rotinaDiaSemana)
        {
            if (id != rotinaDiaSemana.IdRotina)
            {
                return BadRequest();
            }

            _context.Entry(rotinaDiaSemana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotinaDiaSemanaExists(id))
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

        // POST: api/RotinasDiaSemanas
        [HttpPost]
        public async Task<ActionResult<RotinaDiaSemana>> PostRotinaDiaSemana(RotinaDiaSemana rotinaDiaSemana)
        {
            if (_context.RotinaDiaSemana == null)
            {
                return Problem("Entidade 'RotinaDiaSemana' está null.");
            }
            _context.RotinaDiaSemana.Add(rotinaDiaSemana);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RotinaDiaSemanaExists(rotinaDiaSemana.IdRotina))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRotinaDiaSemana", new { id = rotinaDiaSemana.IdRotina }, rotinaDiaSemana);
        }

        // DELETE: api/RotinasDiaSemanas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotinaDiaSemana(int id)
        {
            if (_context.RotinaDiaSemana == null)
            {
                return NotFound();
            }
            var rotinaDiaSemana = await _context.RotinaDiaSemana.FindAsync(id);
            if (rotinaDiaSemana == null)
            {
                return NotFound();
            }

            _context.RotinaDiaSemana.Remove(rotinaDiaSemana);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotinaDiaSemanaExists(int id)
        {
            return (_context.RotinaDiaSemana?.Any(e => e.IdRotina == id)).GetValueOrDefault();
        }
    }
}
