using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Services;
using ApiMobile.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        private readonly RotinaPacienteService _rotinaPacienteService;

        public PacientesController(ApiContext context, IAuthService authService, IMapper mapper, RotinaPacienteService rotinaPacienteService)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
            _rotinaPacienteService = rotinaPacienteService;
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
        public async Task<ActionResult<IEnumerable<Rotina>>> GetAllRotinasDoPaciente(int id)
        {
            var rotinasDoPaciente = await _rotinaPacienteService.GetAllRotinasDoPaciente(id);

            if (rotinasDoPaciente.Count == 0)
            {
                return NotFound();
            }
            return rotinasDoPaciente;
        }

        // GET: api/Pacientes/5/rotinas/1
        [HttpGet("{id}/rotinas/{idRotina}")]
        public async Task<ActionResult<Rotina>> GetRotinaDoPaciente(int id, int idRotina)
        {
            var rotinaDoPaciente = await _rotinaPacienteService.GetRotinaDoPaciente(id, idRotina);

            var rotinaDto = _mapper.Map<RotinaDto>(rotinaDoPaciente);

            return Ok(rotinaDto);
        }

        [HttpGet("{id}/notificacoes")]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetAllNotificacoes(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            var notificacoes = await _context.Notificacao
                .Where(n => n.Rotina.IdPaciente == id)
                .ToListAsync();

            return Ok(notificacoes);
        }

        [HttpGet("{id}/rotinas/notificacoes")]
        public ActionResult<IEnumerable<Notificacao>> GetNotificacoesDaRotina(int id, bool? statusRotinas)
        {
            var query = _context.Notificacao
                .Where(n => n.Rotina.IdPaciente == id);

            if (statusRotinas.HasValue)
            {
                query = query.Where(n => n.Rotina.Ativa == statusRotinas);
            }

            var notificacoes = query.ToList();

            var notificacoesDto = _mapper.Map<List<NotificacaoDto>>(notificacoes);

            return Ok(notificacoesDto);
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
                return Problem("Entity set 'Pacientes'  is null.");
            }
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente", new { id = paciente.IdPaciente }, paciente);
        }

        [HttpPost("{id}/rotinas")]
        public async Task<ActionResult> CreateRotinaDoPaciente(int id, [FromBody] Rotina model)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            var rotina = _mapper.Map<Rotina>(model);
            var notificacoes = rotina.Notificacoes;

            rotina.IdPaciente = id;
            rotina.Paciente = paciente;
            rotina.Notificacoes = null;

            await _context.Rotina.AddAsync(rotina);
            await _context.SaveChangesAsync();

            if (notificacoes != null)
            {
                foreach (var notificacao in notificacoes)
                {
                    notificacao.IdRotina = rotina.IdRotina;
                }
                await _context.Notificacao.AddRangeAsync(notificacoes);
                await _context.SaveChangesAsync();
            }

            rotina.Notificacoes = notificacoes;
            return Ok(rotina);
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