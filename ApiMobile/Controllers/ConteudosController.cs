using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMobile.Models;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudosController : ControllerBase
    {
        private readonly ApiContext _context;

        public ConteudosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Conteudos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conteudo>>> GetConteudos()
        {
          if (_context.Conteudos == null)
          {
              return NotFound();
          }
            return await _context.Conteudos.ToListAsync();
        }

        // GET: api/Conteudos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conteudo>> GetConteudo(int id)
        {
          if (_context.Conteudos == null)
          {
              return NotFound();
          }
            var conteudo = await _context.Conteudos.FindAsync(id);

            if (conteudo == null)
            {
                return NotFound();
            }

            return conteudo;
        }

        // PUT: api/Conteudos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConteudo(int id, Conteudo conteudo)
        {
            if (id != conteudo.IdConteudo)
            {
                return BadRequest();
            }

            _context.Entry(conteudo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConteudoExists(id))
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

        // POST: api/Conteudos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conteudo>> PostConteudo(Conteudo conteudo)
        {
          if (_context.Conteudos == null)
          {
              return Problem("Entity set 'ApiContext.Conteudos'  is null.");
          }
            _context.Conteudos.Add(conteudo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConteudo", new { id = conteudo.IdConteudo }, conteudo);
        }

        // DELETE: api/Conteudos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConteudo(int id)
        {
            if (_context.Conteudos == null)
            {
                return NotFound();
            }
            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }

            _context.Conteudos.Remove(conteudo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConteudoExists(int id)
        {
            return (_context.Conteudos?.Any(e => e.IdConteudo == id)).GetValueOrDefault();
        }
    }
}
