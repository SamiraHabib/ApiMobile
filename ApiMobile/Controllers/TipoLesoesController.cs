using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    public class TipoLesoesController : Controller
    {
        private readonly ApiContext _context;

        public TipoLesoesController(ApiContext context)
        {
            _context = context;
        }

        // GET: TipoLesoes
        public async Task<IActionResult> Index()
        {
            var apiContext = _context.TiposLesao.Include(t => t.Medico);
            return View(await apiContext.ToListAsync());
        }

        // GET: TipoLesoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposLesao == null)
            {
                return NotFound();
            }

            var tipoLesao = await _context.TiposLesao
                .Include(t => t.Medico)
                .FirstOrDefaultAsync(m => m.IdTipoLesao == id);
            if (tipoLesao == null)
            {
                return NotFound();
            }

            return View(tipoLesao);
        }

        // GET: TipoLesoes/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            return View();
        }

        // POST: TipoLesoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoLesao,IdMedico,Nome,Sigla,Descricao,DataCriacao,DataAtualizacao")] TipoLesao tipoLesao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoLesao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", tipoLesao.IdMedico);
            return View(tipoLesao);
        }

        // GET: TipoLesoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposLesao == null)
            {
                return NotFound();
            }

            var tipoLesao = await _context.TiposLesao.FindAsync(id);
            if (tipoLesao == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", tipoLesao.IdMedico);
            return View(tipoLesao);
        }

        // POST: TipoLesoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoLesao,IdMedico,Nome,Sigla,Descricao,DataCriacao,DataAtualizacao")] TipoLesao tipoLesao)
        {
            if (id != tipoLesao.IdTipoLesao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoLesao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoLesaoExists(tipoLesao.IdTipoLesao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", tipoLesao.IdMedico);
            return View(tipoLesao);
        }

        // GET: TipoLesoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposLesao == null)
            {
                return NotFound();
            }

            var tipoLesao = await _context.TiposLesao
                .Include(t => t.Medico)
                .FirstOrDefaultAsync(m => m.IdTipoLesao == id);
            if (tipoLesao == null)
            {
                return NotFound();
            }

            return View(tipoLesao);
        }

        // POST: TipoLesoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposLesao == null)
            {
                return Problem("Entity set 'ApiContext.TiposLesao'  is null.");
            }
            var tipoLesao = await _context.TiposLesao.FindAsync(id);
            if (tipoLesao != null)
            {
                _context.TiposLesao.Remove(tipoLesao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoLesaoExists(int id)
        {
          return (_context.TiposLesao?.Any(e => e.IdTipoLesao == id)).GetValueOrDefault();
        }
    }
}
