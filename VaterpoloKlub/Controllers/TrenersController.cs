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
    public class TrenersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrenersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treners
        public async Task<IActionResult> Index(string filter)
        {
            Console.WriteLine(filter);
            return View(await _context.Treneri.Where(x => filter == null || (x.Ime + " " + x.Prezime).ToLower().Contains(filter)).ToListAsync());
        }

        // GET: Treners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treneri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // GET: Treners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,DatumRodjenja,Email")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trener);
        }

        // GET: Treners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treneri.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }
            return View(trener);
        }

        // POST: Treners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,DatumRodjenja,Email")] Trener trener)
        {
            if (id != trener.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenerExists(trener.Id))
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
            return View(trener);
        }

        // GET: Treners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treneri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // POST: Treners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trener = await _context.Treneri.FindAsync(id);
            _context.Treneri.Remove(trener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenerExists(int id)
        {
            return _context.Treneri.Any(e => e.Id == id);
        }
    }
}
