using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacoesController : ControllerBase
    {
        private readonly ApiContext _context;

        public NotificacoesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Notificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetNotificacao()
        {
            if (_context.Notificacao == null)
            {
                return NotFound();
            }
            return await _context.Notificacao.ToListAsync();
        }

        // GET: api/Notificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacao>> GetNotificacao(int id)
        {
            if (_context.Notificacao == null)
            {
                return NotFound();
            }
            var notificacao = await _context.Notificacao.FindAsync(id);

            if (notificacao == null)
            {
                return NotFound();
            }
            return notificacao;
        }

        // PUT: api/Notificacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacao(int id, Notificacao notificacao)
        {
            if (id != notificacao.IdNotificacao)
            {
                return BadRequest();
            }

            _context.Entry(notificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacaoExists(id))
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

        // POST: api/Notificacoes
        [HttpPost]
        public async Task<ActionResult<Notificacao>> PostNotificacao(Notificacao notificacao)
        {
            if (_context.Notificacao == null)
            {
                return Problem("Entity set 'ApiContext.Notificacao'  is null.");
            }
            _context.Notificacao.Add(notificacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacao", new { id = notificacao.IdNotificacao }, notificacao);
        }

        // DELETE: api/Notificacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacao(int id)
        {
            if (_context.Notificacao == null)
            {
                return NotFound();
            }
            var notificacao = await _context.Notificacao.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }

            _context.Notificacao.Remove(notificacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificacaoExists(int id)
        {
            return (_context.Notificacao?.Any(e => e.IdNotificacao == id)).GetValueOrDefault();
        }
    }
}