using ApiMobile.Models;
using ApiMobile.Service;
using ApiMobile.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IAuthService _authService;

        public MedicosController(ApiContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            if (_context.Medicos == null)
            {
                return NotFound();
            }
            return await _context.Medicos.ToListAsync();
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            if (_context.Medicos == null)
            {
                return NotFound();
            }
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return medico;
        }

        // PUT: api/Medicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/Medicos
        [HttpPost]
        public async Task<ActionResult<Medico>> PostMedico(Medico medico)
        {
            if (_context.Medicos == null)
            {
                return Problem("Entity set 'ApiContext.Medicos'  is null.");
            }
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = medico.IdMedico }, medico);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            if (_context.Medicos == null)
            {
                return NotFound();
            }
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> MedicoLogin([FromBody] LoginViewModel model)
        {
            var medico = await _authService.ValidateCredentials(model.Email, model.Senha);
            if (medico == null)
            {
                return Unauthorized();
            }

            var authenticatedUser = new UsuarioAutentificado();

            var token = _authService.GenerateJwtToken(authenticatedUser);

            return Ok(new { token });
        }

        private bool MedicoExists(int id)
        {
            return (_context.Medicos?.Any(e => e.IdMedico == id)).GetValueOrDefault();
        }
    }
}