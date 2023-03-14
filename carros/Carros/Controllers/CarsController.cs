using Carros.Data;
using Carros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carros.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        public async Task <IActionResult> Details(int? id)
        {
            if(id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
        
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if(ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if(id != car.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!CarExists(car.Id))
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
            return View(car);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Cars == null)
            {
                return Problem("Entidade'ApplicationDbContext.Cars' não encontrada.");
            }
            var car = await _context.Cars.FindAsync(id);
            if(car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
