using ClientePedidoIdentity.Data;
using ClientePedidoIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PedidoPedidoIdentity.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context) =>
            _context = context;

        public async Task<IActionResult> Index() =>
            View(await _context.Pedidos.ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
                return NotFound();

            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
                return NotFound();

            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExiste(pedido.Id))
                        return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
                return NotFound();

            var pedido = await _context.Pedidos.FirstOrDefaultAsync(c => c.Id == id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
                return Problem("Entidade'ApplicationDbContext.Pedidos' não encontrado");

            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido != null)
                _context.Remove(pedido);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExiste(int id) => _context.Pedidos.Any(p => p.Id == id);
    }
}
