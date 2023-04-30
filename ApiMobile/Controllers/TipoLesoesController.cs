using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLesoesController : ControllerBase
    {
        private readonly ApiContext _context;

        public TipoLesoesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/TipoLesoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLesao>>> GetTiposLesao()
        {
            if (_context.TiposLesao == null)
            {
                return NotFound();
            }
            return await _context.TiposLesao.ToListAsync();
        }

        // GET: api/TipoLesoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLesao>> GetTipoLesao(int id)
        {
            if (_context.TiposLesao == null)
            {
                return NotFound();
            }
            var tipoLesao = await _context.TiposLesao.FindAsync(id);

            if (tipoLesao == null)
            {
                return NotFound();
            }

            return tipoLesao;
        }

        // PUT: api/TipoLesoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoLesao(int id, TipoLesao tipoLesao)
        {
            if (id != tipoLesao.IdTipoLesao)
            {
                return BadRequest();
            }

            _context.Entry(tipoLesao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLesaoExists(id))
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

        // POST: api/TipoLesoes
        [HttpPost]
        public async Task<ActionResult<TipoLesao>> PostTipoLesao(TipoLesao tipoLesao)
        {
            if (_context.TiposLesao == null)
            {
                return Problem("Entity set 'ApiContext.TiposLesao'  is null.");
            }
            _context.TiposLesao.Add(tipoLesao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoLesao", new { id = tipoLesao.IdTipoLesao }, tipoLesao);
        }

        // DELETE: api/TipoLesoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoLesao(int id)
        {
            if (_context.TiposLesao == null)
            {
                return NotFound();
            }
            var tipoLesao = await _context.TiposLesao.FindAsync(id);
            if (tipoLesao == null)
            {
                return NotFound();
            }

            _context.TiposLesao.Remove(tipoLesao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoLesaoExists(int id)
        {
            return (_context.TiposLesao?.Any(e => e.IdTipoLesao == id)).GetValueOrDefault();
        }
    }
}