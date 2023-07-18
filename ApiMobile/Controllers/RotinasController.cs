using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinasController : ControllerBase
    {
        private readonly ApiContext _context;

        public RotinasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Rotinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rotina>>> GetRotina()
        {
            if (_context.Rotina == null)
            {
                return NotFound();
            }
            return await _context.Rotina.ToListAsync();
        }

        // GET: api/Rotinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rotina>> GetRotina(int id)
        {
            if (_context.Rotina == null)
            {
                return NotFound();
            }
            var rotina = await _context.Rotina.FindAsync(id);

            if (rotina == null)
            {
                return NotFound();
            }

            return rotina;
        }

        // PUT: api/Rotinas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotina(int id, Rotina rotina)
        {
            if (id != rotina.IdRotina)
            {
                return BadRequest();
            }

            _context.Entry(rotina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotinaExists(id))
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

        // POST: api/Rotinas
        [HttpPost]
        public async Task<ActionResult<Rotina>> PostRotina(Rotina rotina)
        {
            if (_context.Rotina == null)
            {
                return Problem("Entity set 'ApiContext.Rotina'  is null.");
            }
            _context.Rotina.Add(rotina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRotina", new { id = rotina.IdRotina }, rotina);
        }

        // DELETE: api/Rotinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotina(int id)
        {
            var rotina = await _context.Rotina
                .Include(r => r.Notificacoes)
                .FirstOrDefaultAsync(r => r.IdRotina == id);
            
            if (rotina == null) return NotFound();
            
            if (rotina.Notificacoes != null && rotina.Notificacoes.Any())
            {
                _context.Notificacao.RemoveRange(rotina.Notificacoes);
            }

            _context.Rotina.Remove(rotina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotinaExists(int id)
        {
            return (_context.Rotina?.Any(e => e.IdRotina == id)).GetValueOrDefault();
        }
    }
}
