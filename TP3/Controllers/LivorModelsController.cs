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
    public class LivorModelsController : Controller
    {
        private readonly TP3Context _context;
 
        public LivorModelsController(TP3Context context)
        {
            _context = context;
        }

        // GET: LivorModels
        public async Task<IActionResult> Index()
        {
              return _context.LivorModel != null ? 
                          View(await _context.LivorModel.ToListAsync()) :
                          Problem("Entity set 'TP3Context.LivorModel'  is null.");
        }

        // GET: LivorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LivorModel == null)
            {
                return NotFound();
            }

            var livorModel = await _context.LivorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livorModel == null)
            {
                return NotFound();
            }

            return View(livorModel);
        }

        // GET: LivorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LivorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Preco")] LivorModel livorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livorModel);
        }

        // GET: LivorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LivorModel == null)
            {
                return NotFound();
            }

            var livorModel = await _context.LivorModel.FindAsync(id);
            if (livorModel == null)
            {
                return NotFound();
            }
            return View(livorModel);
        }

        // POST: LivorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Preco")] LivorModel livorModel)
        {
            if (id != livorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivorModelExists(livorModel.Id))
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
            return View(livorModel);
        }

        // GET: LivorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LivorModel == null)
            {
                return NotFound();
            }

            var livorModel = await _context.LivorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livorModel == null)
            {
                return NotFound();
            }

            return View(livorModel);
        }

        // POST: LivorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LivorModel == null)
            {
                return Problem("Entity set 'TP3Context.LivorModel'  is null.");
            }
            var livorModel = await _context.LivorModel.FindAsync(id);
            if (livorModel != null)
            {
                _context.LivorModel.Remove(livorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivorModelExists(int id)
        {
          return (_context.LivorModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
