using ApiMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Controllers
{
    public class DiaSemanasController : Controller
    {
        private readonly ApiContext _context;

        public DiaSemanasController(ApiContext context)
        {
            _context = context;
        }

        // GET: DiaSemanas
        public async Task<IActionResult> Index()
        {
              return _context.DiasSemana != null ? 
                          View(await _context.DiasSemana.ToListAsync()) :
                          Problem("Entity set 'ApiContext.DiasSemana'  is null.");
        }

        // GET: DiaSemanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiasSemana == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana
                .FirstOrDefaultAsync(m => m.IdDiaSemana == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // GET: DiaSemanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaSemanas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiaSemana,Nome")] DiaSemana diaSemana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaSemana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaSemana);
        }

        // GET: DiaSemanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiasSemana == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana.FindAsync(id);
            if (diaSemana == null)
            {
                return NotFound();
            }
            return View(diaSemana);
        }

        // POST: DiaSemanas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiaSemana,Nome")] DiaSemana diaSemana)
        {
            if (id != diaSemana.IdDiaSemana)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaSemana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaSemanaExists(diaSemana.IdDiaSemana))
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
            return View(diaSemana);
        }

        // GET: DiaSemanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiasSemana == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiasSemana
                .FirstOrDefaultAsync(m => m.IdDiaSemana == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // POST: DiaSemanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiasSemana == null)
            {
                return Problem("Entity set 'ApiContext.DiasSemana'  is null.");
            }
            var diaSemana = await _context.DiasSemana.FindAsync(id);
            if (diaSemana != null)
            {
                _context.DiasSemana.Remove(diaSemana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaSemanaExists(int id)
        {
          return (_context.DiasSemana?.Any(e => e.IdDiaSemana == id)).GetValueOrDefault();
        }
    }
}
