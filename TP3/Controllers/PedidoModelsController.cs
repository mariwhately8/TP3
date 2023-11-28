using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;

namespace TP3.Controllers
{
    public class PedidoModelsController : Controller
    {
        private readonly TP3Context _context;

        public PedidoModelsController(TP3Context context)
        {
            _context = context;
        }

        // GET: PedidoModels
        public async Task<IActionResult> Index()
        {
              return _context.PedidoModel != null ? 
                          View(await _context.PedidoModel.ToListAsync()) :
                          Problem("Entity set 'TP3Context.PedidoModel'  is null.");
        }

        // GET: PedidoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidoModel == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: PedidoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pedido,DataPedido")] PedidoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoModel);
        }

        // GET: PedidoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidoModel == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }
            return View(pedidoModel);
        }

        // POST: PedidoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pedido,DataPedido")] PedidoModel pedidoModel)
        {
            if (id != pedidoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoModelExists(pedidoModel.Id))
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
            return View(pedidoModel);
        }

        // GET: PedidoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidoModel == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: PedidoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidoModel == null)
            {
                return Problem("Entity set 'TP3Context.PedidoModel'  is null.");
            }
            var pedidoModel = await _context.PedidoModel.FindAsync(id);
            if (pedidoModel != null)
            {
                _context.PedidoModel.Remove(pedidoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoModelExists(int id)
        {
          return (_context.PedidoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
