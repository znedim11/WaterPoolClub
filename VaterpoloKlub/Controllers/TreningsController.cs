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
    public class TreningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trenings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trening.Include(t => t.Bazen).Include(t => t.Trener).Include(t => t.VrstaTreninga);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Trening
                .Include(t => t.Bazen)
                .Include(t => t.Trener)
                .Include(t => t.VrstaTreninga)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // GET: Trenings/Create
        public IActionResult Create()
        {
            ViewData["BazenID"] = new SelectList(_context.Bazen, "ID", "Naziv");
            ViewData["TrenerID"] = new SelectList(_context.OrganizacijaZaCertifikacije, "Id", "Ime");
            ViewData["VrstaTreningaID"] = new SelectList(_context.VrstaTreninga, "ID", "NazivTreninga");
            return View();
        }

        // POST: Trenings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Datum,TrenerID,BazenID,VrstaTreningaID")] Trening trening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BazenID"] = new SelectList(_context.Bazen, "ID", "Naziv");
            ViewData["TrenerID"] = new SelectList(_context.OrganizacijaZaCertifikacije, "Id", "Ime");
            ViewData["VrstaTreningaID"] = new SelectList(_context.VrstaTreninga, "ID", "NazivTreninga");


            return View(trening);
        }

        // GET: Trenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Trening.FindAsync(id);
            if (trening == null)
            {
                return NotFound();
            }
            ViewData["BazenID"] = new SelectList(_context.Bazen, "ID", "Naziv", trening.BazenID);
            ViewData["TrenerID"] = new SelectList(_context.OrganizacijaZaCertifikacije, "Id", "Ime", trening.TrenerID);
            ViewData["VrstaTreningaID"] = new SelectList(_context.VrstaTreninga, "ID", "NazivTreninga", trening.VrstaTreningaID);
            return View(trening);
        }

        // POST: Trenings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Datum,TrenerID,BazenID,VrstaTreningaID")] Trening trening)
        {
            if (id != trening.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreningExists(trening.ID))
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
            ViewData["BazenID"] = new SelectList(_context.Bazen, "ID", "Naziv", trening.BazenID);
            ViewData["TrenerID"] = new SelectList(_context.OrganizacijaZaCertifikacije, "Id", "Ime", trening.TrenerID);
            ViewData["VrstaTreningaID"] = new SelectList(_context.VrstaTreninga, "ID", "NazivTreninga", trening.VrstaTreningaID);
            return View(trening);
        }

        // GET: Trenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trening = await _context.Trening
                .Include(t => t.Bazen)
                .Include(t => t.Trener)
                .Include(t => t.VrstaTreninga)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trening == null)
            {
                return NotFound();
            }

            return View(trening);
        }

        // POST: Trenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trening = await _context.Trening.FindAsync(id);
            _context.Trening.Remove(trening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreningExists(int id)
        {
            return _context.Trening.Any(e => e.ID == id);
        }
    }
}
