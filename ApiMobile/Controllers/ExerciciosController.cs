using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    public class ExerciciosController : Controller
    {
        private readonly ApiContext _context;

        public ExerciciosController(ApiContext context)
        {
            _context = context;
        }

        // GET: Exercicios
        public async Task<IActionResult> Index()
        {
            var apiContext = _context.Exercicios.Include(e => e.Medico).Include(e => e.TipoLesao);
            return View(await apiContext.ToListAsync());
        }

        // GET: Exercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios
                .Include(e => e.Medico)
                .Include(e => e.TipoLesao)
                .FirstOrDefaultAsync(m => m.IdExercicio == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        // GET: Exercicios/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico");
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao");
            return View();
        }

        // POST: Exercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExercicio,IdMedico,IdTipoLesao,Nome,Descricao,Instrucoes,EncodedGif,Precaucoes,Observacoes,DataCriacao,DataAtualizacao")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", exercicio.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", exercicio.IdTipoLesao);
            return View(exercicio);
        }

        // GET: Exercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", exercicio.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", exercicio.IdTipoLesao);
            return View(exercicio);
        }

        // POST: Exercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExercicio,IdMedico,IdTipoLesao,Nome,Descricao,Instrucoes,EncodedGif,Precaucoes,Observacoes,DataCriacao,DataAtualizacao")] Exercicio exercicio)
        {
            if (id != exercicio.IdExercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioExists(exercicio.IdExercicio))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", exercicio.IdMedico);
            ViewData["IdTipoLesao"] = new SelectList(_context.TiposLesao, "IdTipoLesao", "IdTipoLesao", exercicio.IdTipoLesao);
            return View(exercicio);
        }

        // GET: Exercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exercicios == null)
            {
                return NotFound();
            }

            var exercicio = await _context.Exercicios
                .Include(e => e.Medico)
                .Include(e => e.TipoLesao)
                .FirstOrDefaultAsync(m => m.IdExercicio == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            return View(exercicio);
        }

        // POST: Exercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exercicios == null)
            {
                return Problem("Entity set 'ApiContext.Exercicios'  is null.");
            }
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio != null)
            {
                _context.Exercicios.Remove(exercicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioExists(int id)
        {
          return (_context.Exercicios?.Any(e => e.IdExercicio == id)).GetValueOrDefault();
        }
    }
}
