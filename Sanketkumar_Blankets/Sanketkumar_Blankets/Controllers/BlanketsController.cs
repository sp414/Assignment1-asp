using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sanketkumar_Blankets.Data;
using Sanketkumar_Blankets.Models;

namespace Sanketkumar_Blankets.Controllers
{
    public class BlanketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlanketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blankets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blankets.ToListAsync());
        }

        // GET: Blankets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blankets = await _context.Blankets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blankets == null)
            {
                return NotFound();
            }

            return View(blankets);
        }

        // GET: Blankets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blankets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price")] Blankets blankets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blankets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blankets);
        }

        // GET: Blankets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blankets = await _context.Blankets.FindAsync(id);
            if (blankets == null)
            {
                return NotFound();
            }
            return View(blankets);
        }

        // POST: Blankets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price")] Blankets blankets)
        {
            if (id != blankets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blankets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlanketsExists(blankets.Id))
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
            return View(blankets);
        }

        // GET: Blankets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blankets = await _context.Blankets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blankets == null)
            {
                return NotFound();
            }

            return View(blankets);
        }

        // POST: Blankets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blankets = await _context.Blankets.FindAsync(id);
            _context.Blankets.Remove(blankets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlanketsExists(int id)
        {
            return _context.Blankets.Any(e => e.Id == id);
        }
    }
}
