using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    public class ConteudosController : Controller
    {
        private readonly ApiContext _context;

        public ConteudosController(ApiContext context)
        {
            _context = context;
        }

        // GET: Conteudos
        public async Task<IActionResult> Index()
        {
            var apiContext = _context.Conteudos.Include(c => c.Medico).Include(c => c.TipoLesao);
            return View(await apiContext.ToListAsync());
        }

        // GET: Conteudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conteudos == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos
                .Include(c => c.Medico)
                .Include(c => c.TipoLesao)
                .FirstOrDefaultAsync(m => m.IdConteudo == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudos/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao");
            return View();
        }

        // POST: Conteudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConteudo,IdMedico,IdTipoLesao,Titulo,Subtitulo,Descricao,Observacao,DataCriacao,DataAtualizacao")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", conteudo.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", conteudo.IdTipoLesao);
            return View(conteudo);
        }

        // GET: Conteudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conteudos == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", conteudo.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", conteudo.IdTipoLesao);
            return View(conteudo);
        }

        // POST: Conteudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConteudo,IdMedico,IdTipoLesao,Titulo,Subtitulo,Descricao,Observacao,DataCriacao,DataAtualizacao")] Conteudo conteudo)
        {
            if (id != conteudo.IdConteudo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.IdConteudo))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", conteudo.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", conteudo.IdTipoLesao);
            return View(conteudo);
        }

        // GET: Conteudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conteudos == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudos
                .Include(c => c.Medico)
                .Include(c => c.TipoLesao)
                .FirstOrDefaultAsync(m => m.IdConteudo == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // POST: Conteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conteudos == null)
            {
                return Problem("Entity set 'ApiContext.Conteudos'  is null.");
            }
            var conteudo = await _context.Conteudos.FindAsync(id);
            if (conteudo != null)
            {
                _context.Conteudos.Remove(conteudo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExists(int id)
        {
          return (_context.Conteudos?.Any(e => e.IdConteudo == id)).GetValueOrDefault();
        }
    }
}
