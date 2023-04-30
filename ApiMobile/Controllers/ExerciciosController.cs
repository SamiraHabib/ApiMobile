using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciciosController : ControllerBase
    {
        private readonly ApiContext _context;

        public ExerciciosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Exercicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercicio>>> GetExercicios()
        {
            if (_context.Exercicios == null)
            {
                return NotFound();
            }
            return await _context.Exercicios.ToListAsync();
        }

        // GET: api/Exercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> GetExercicio(int id)
        {
            if (_context.Exercicios == null)
            {
                return NotFound();
            }
            var exercicio = await _context.Exercicios.FindAsync(id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return exercicio;
        }

        // PUT: api/Exercicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicio(int id, Exercicio exercicio)
        {
            if (id != exercicio.IdExercicio)
            {
                return BadRequest();
            }

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        // POST: api/Exercicios
        [HttpPost]
        public async Task<ActionResult<Exercicio>> PostExercicio(Exercicio exercicio)
        {
            if (_context.Exercicios == null)
            {
                return Problem("Entity set 'ApiContext.Exercicios'  is null.");
            }
            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicio", new { id = exercicio.IdExercicio }, exercicio);
        }

        // DELETE: api/Exercicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicio(int id)
        {
            if (_context.Exercicios == null)
            {
                return NotFound();
            }
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercicioExists(int id)
        {
            return (_context.Exercicios?.Any(e => e.IdExercicio == id)).GetValueOrDefault();
        }
    }
}