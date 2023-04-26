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
    public class DiaSemanasController : ControllerBase
    {
        private readonly ApiContext _context;

        public DiaSemanasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/DiaSemanas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaSemana>>> GetDiasSemana()
        {
          if (_context.DiasSemana == null)
          {
              return NotFound();
          }
            return await _context.DiasSemana.ToListAsync();
        }

        // GET: api/DiaSemanas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaSemana>> GetDiaSemana(int id)
        {
          if (_context.DiasSemana == null)
          {
              return NotFound();
          }
            var diaSemana = await _context.DiasSemana.FindAsync(id);

            if (diaSemana == null)
            {
                return NotFound();
            }

            return diaSemana;
        }

        // PUT: api/DiaSemanas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaSemana(int id, DiaSemana diaSemana)
        {
            if (id != diaSemana.IdDiaSemana)
            {
                return BadRequest();
            }

            _context.Entry(diaSemana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaSemanaExists(id))
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

        // POST: api/DiaSemanas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaSemana>> PostDiaSemana(DiaSemana diaSemana)
        {
          if (_context.DiasSemana == null)
          {
              return Problem("Entity set 'ApiContext.DiasSemana'  is null.");
          }
            _context.DiasSemana.Add(diaSemana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaSemana", new { id = diaSemana.IdDiaSemana }, diaSemana);
        }

        // DELETE: api/DiaSemanas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaSemana(int id)
        {
            if (_context.DiasSemana == null)
            {
                return NotFound();
            }
            var diaSemana = await _context.DiasSemana.FindAsync(id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            _context.DiasSemana.Remove(diaSemana);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaSemanaExists(int id)
        {
            return (_context.DiasSemana?.Any(e => e.IdDiaSemana == id)).GetValueOrDefault();
        }
    }
}
