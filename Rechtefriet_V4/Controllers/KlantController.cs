using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rechtefriet;
using Rechtefriet_V4.Data;

namespace Rechtefriet_V4.Controllers
{
    public class KlantController : Controller
    {
        private readonly RechtefrietDB_V2 _context;

        public KlantController(RechtefrietDB_V2 context)
        {
            _context = context;
        }

        // GET: Klant
        public async Task<IActionResult> Index()
        {
              return _context.Klants != null ? 
                          View(await _context.Klants.ToListAsync()) :
                          Problem("Entity set 'RechtefrietDB_V2.Klants'  is null.");
        }

        // GET: Klant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klants == null)
            {
                return NotFound();
            }

            var klant = await _context.Klants
                .FirstOrDefaultAsync(m => m.Klantid == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Klant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Klantid,Name,Adress")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klant);
            
        }

        // GET: Klant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klants == null)
            {
                return NotFound();
            }

            var klant = await _context.Klants.FindAsync(id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Klant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Klantid,Name,Adress")] Klant klant)
        {
            if (id != klant.Klantid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Klantid))
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
            return View(klant);
        }

        // GET: Klant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klants == null)
            {
                return NotFound();
            }

            var klant = await _context.Klants
                .FirstOrDefaultAsync(m => m.Klantid == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klants == null)
            {
                return Problem("Entity set 'RechtefrietDB_V2.Klants'  is null.");
            }
            var klant = await _context.Klants.FindAsync(id);
            if (klant != null)
            {
                _context.Klants.Remove(klant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(int id)
        {
          return (_context.Klants?.Any(e => e.Klantid == id)).GetValueOrDefault();
        }
    }
}
