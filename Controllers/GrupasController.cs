using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lista25.Models;

namespace Lista25.Controllers
{
    public class GrupasController : Controller
    {
        private readonly ListaWwwContext _context;

        public GrupasController(ListaWwwContext context)
        {
            _context = context;
        }

        // GET: Grupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grupas.ToListAsync());
        }

        // GET: Grupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // GET: Grupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grupa1")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupa);
        }

        // GET: Grupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupas.FindAsync(id);
            if (grupa == null)
            {
                return NotFound();
            }
            return View(grupa);
        }

        // POST: Grupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grupa1")] Grupa grupa)
        {
            if (id != grupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupaExists(grupa.Id))
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
            return View(grupa);
        }

        // GET: Grupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // POST: Grupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupa = await _context.Grupas.FindAsync(id);
            if (grupa != null)
            {
                _context.Grupas.Remove(grupa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupaExists(int id)
        {
            return _context.Grupas.Any(e => e.Id == id);
        }
    }
}
