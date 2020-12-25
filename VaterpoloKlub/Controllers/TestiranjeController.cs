using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Data;
using VaterpoloKlub.Models;

namespace VaterpoloKlub.Controllers
{
    public class TestiranjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestiranjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Testiranje
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Testiranja.Include(t => t.Trener);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Testiranje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testiranje = await _context.Testiranja
                .Include(t => t.Trener)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testiranje == null)
            {
                return NotFound();
            }

            return View(testiranje);
        }

        // GET: Testiranje/Create
        public IActionResult Create()
        {
            ViewData["TrenerId"] = new SelectList(_context.Treneri, "Id", "Id");
            return View();
        }

        // POST: Testiranje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrenerId,DatumTestiranja,NazivTestiranja")] Testiranje testiranje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testiranje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrenerId"] = new SelectList(_context.Treneri, "Id", "Id", testiranje.TrenerId);
            return View(testiranje);
        }

        // GET: Testiranje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testiranje = await _context.Testiranja.FindAsync(id);
            if (testiranje == null)
            {
                return NotFound();
            }
            ViewData["TrenerId"] = new SelectList(_context.Treneri, "Id", "Id", testiranje.TrenerId);
            return View(testiranje);
        }

        // POST: Testiranje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrenerId,DatumTestiranja,NazivTestiranja")] Testiranje testiranje)
        {
            if (id != testiranje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testiranje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestiranjeExists(testiranje.Id))
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
            ViewData["TrenerId"] = new SelectList(_context.Treneri, "Id", "Id", testiranje.TrenerId);
            return View(testiranje);
        }

        // GET: Testiranje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testiranje = await _context.Testiranja
                .Include(t => t.Trener)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testiranje == null)
            {
                return NotFound();
            }

            return View(testiranje);
        }

        // POST: Testiranje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testiranje = await _context.Testiranja.FindAsync(id);
            _context.Testiranja.Remove(testiranje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestiranjeExists(int id)
        {
            return _context.Testiranja.Any(e => e.Id == id);
        }
    }
}
