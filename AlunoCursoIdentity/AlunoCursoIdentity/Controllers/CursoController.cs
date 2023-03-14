using AlunoCursoIdentity.Data;
using AlunoCursoIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunoCursoIdentity.Controllers
{
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Curso.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(curso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
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
            return View(curso);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curso == null)
            {
                return Problem("Entidade'ApplicationDbContext.Curso' não encontrada.");
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso != null)
            {
                _context.Curso.Remove(curso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
