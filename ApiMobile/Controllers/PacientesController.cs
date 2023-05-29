using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IAuthService _authService;

        public PacientesController(ApiContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: api/Pacientes
        [HttpGet]
        [Authorize(Policy = "PacientePolicy")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            if (_context.Pacientes == null)
            {
                return NotFound();
            }
            return await _context.Pacientes.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        [Authorize(Policy = "PacientePolicy")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            if (_context.Pacientes == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }

        // GET: api/Pacientes/5/rotinas
        [HttpGet("{id}/rotinas")]
        public async Task<ActionResult<IEnumerable<Rotina>>> GetRotinasDoPaciente(int  id)
        {
            var rotinasDoPaciente = await _context.Rotina
                .Where(r => r.IdPaciente == id)
                .ToListAsync();

            if (rotinasDoPaciente.Count == 0)
            {
                return NotFound();
            }
            return rotinasDoPaciente;
        }

        [HttpGet("{id}/rotinas/{idRotina}")]
        public async Task<ActionResult<Rotina>> GetRotinaDoPaciente(int id, int idRotina)
        {
            var rotinaDoPaciente = await _context.Rotina
                .Where(r => r.IdPaciente == id && r.IdRotina == idRotina)
                .Include(r => r.Exercicios)
                .Include(r => r.DiasSemana)
                .Include(r => r.Notificacoes)
                .FirstOrDefaultAsync();

            if (rotinaDoPaciente == null)
            {
                return NotFound();
            }
            return rotinaDoPaciente;
        }

        [HttpGet("{id}/rotinas/notificacoes")]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetNotificacoesDoPaciente(int id, bool? statusRotinas)
        {
            var query = _context.Notificacao.Where(n => n.Rotina.IdPaciente == id);

            if (statusRotinas.HasValue)
            {
                query = query.Where(n => n.Rotina.Ativa == statusRotinas);
            }

            var notificacoesDoPaciente = await query
                .Select(n => new
                {
                    n.IdNotificacao,
                    n.Rotina.IdRotina,
                    n.Titulo,
                    n.Mensagem,
                    n.Hora
                })
                .ToListAsync();

            if (notificacoesDoPaciente.Count == 0)
            {
                return NotFound();
            }

            return notificacoesDoPaciente.Select(n => new Notificacao
            {
                IdNotificacao = n.IdNotificacao,
                IdRotina = n.IdRotina,
                Titulo = n.Titulo,
                Mensagem = n.Mensagem,
                Hora = n.Hora
            }).ToList();
        }

        [HttpGet("{idPaciente}/notificacoes")]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetNotificacoes(int id)
        {
            // Verificar se o paciente existe
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            // Obter as notificações do paciente
            var notificacoes = await _context.Notificacao
                .Where(n => n.Rotina.Paciente.IdPaciente == id)
                .ToListAsync();

            return Ok(notificacoes);
        }

        // PUT: api/Pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Pacientes
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'ApiContext.Pacientes'  is null.");
            }
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente", new { id = paciente.IdPaciente }, paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            if (_context.Pacientes == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> PacienteLogin([FromBody] Login model)
        {
            var paciente = await _authService.ValidateCredentials(model.Email, model.Senha);
            if (paciente == null)
            {
                return Unauthorized();
            }

            var authenticatedUser = new UsuarioAutenticado();

            var token = _authService.GenerateJwtToken(authenticatedUser);

            return Ok(new { token });
        }

        private bool PacienteExists(int id)
        {
            return (_context.Pacientes?.Any(e => e.IdPaciente == id)).GetValueOrDefault();
        }
    }
}