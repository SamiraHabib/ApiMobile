using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}