using ApiMobile.DTO;
using ApiMobile.Models;
using ApiMobile.Services;
using ApiMobile.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IAuthService _authService;
        private readonly ICRMApiService _crmapiService;

        public UsuariosController(ApiContext context, IAuthService authService, ICRMApiService crmService)
        {
            _context = context;
            _authService = authService;
            _crmapiService = crmService;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            return await _context.Usuarios
                .Include(u => u.Medico)
                .Include(u => u.Paciente)
                .ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ApiContext.Usuarios'  is null.");
            }

            var userExists = await _context.Usuarios.Where(u => u.Email.ToLower().Trim() == usuario.Email.ToLower().Trim()).FirstOrDefaultAsync();

            if (userExists != null)
            {
                return BadRequest("Email já cadastrado.");
            }

            if (usuario.Medico != null)
            {
                var medico = usuario.Medico;

                var crm = await _crmapiService.GetMedicosAsync(medico.NumeroCrm, medico.UfCrm);
                var validCrm = crm.Itens.ElementAtOrDefault(0);

                var ufIsEqual = validCrm?.UF == medico.UfCrm;
                var numCrmIsEqual = validCrm?.Numero == medico.NumeroCrm;
                var isCrmAtivo = validCrm?.Situacao.ToLower() == "ativo";

                usuario.Medico.SituacaoCrm = validCrm.Situacao;

                if (!ufIsEqual || !numCrmIsEqual || !isCrmAtivo)
                {
                    return Unauthorized("Invalid CRM");
                }
            }

            var senha = usuario.SenhaEncriptada;
            usuario.SenhaEncriptada = BCrypt.Net.BCrypt.HashPassword(senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> UsuarioLogin([FromBody] Login model)
        {
            var usuario = await _authService.ValidateCredentials(model.Email, model.Senha);
            if (usuario == null)
            {
                return Unauthorized();
            }

            var authenticatedUser = new UsuarioAutenticado
            {
                Id = usuario.IdUsuario,
                Email = usuario.Email,
                Name = usuario.Email,
                Role = usuario.Medico == null ? "Paciente" : "Medico",
                Usuario = usuario
            };

            var token = _authService.GenerateJwtToken(authenticatedUser);

            authenticatedUser.Auth = token;

            return Ok(authenticatedUser);
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}