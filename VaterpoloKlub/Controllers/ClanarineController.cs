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
    public class ClanarineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClanarineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clanarine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clanarine.Include(c => c.Clan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clanarine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clanarina = await _context.Clanarine
                .Include(c => c.Clan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clanarina == null)
            {
                return NotFound();
            }

            return View(clanarina);
        }

        // GET: Clanarine/Create
        public IActionResult Create()
        {
            ViewData["Clan"] = new SelectList(_context.Clanovi.ToList(), "ID", nameof(Clan.Ime));
            return View();
        }

        // POST: Clanarine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatumPocketa,DatumKraja,ClanId")] Clanarina clanarina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clanarina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", clanarina.ClanId);
            return View(clanarina);
        }

        // GET: Clanarine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clanarina = await _context.Clanarine.FindAsync(id);
            if (clanarina == null)
            {
                return NotFound();
            }
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", clanarina.ClanId);
            return View(clanarina);
        }

        // POST: Clanarine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatumPocketa,DatumKraja,ClanId")] Clanarina clanarina)
        {
            if (id != clanarina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clanarina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClanarinaExists(clanarina.Id))
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
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", clanarina.ClanId);
            return View(clanarina);
        }

        // GET: Clanarine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clanarina = await _context.Clanarine
                .Include(c => c.Clan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clanarina == null)
            {
                return NotFound();
            }

            return View(clanarina);
        }

        // POST: Clanarine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clanarina = await _context.Clanarine.FindAsync(id);
            _context.Clanarine.Remove(clanarina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClanarinaExists(int id)
        {
            return _context.Clanarine.Any(e => e.Id == id);
        }
    }
}
