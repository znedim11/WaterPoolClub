using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Data;
using VaterpoloKlub.Models;

namespace VaterpoloKlub
{
    public class NaplataClanarineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaplataClanarineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NaplataClanarine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NaplataClanarina.Include(n => n.Clanarina).Include(n => n.Upravnik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NaplataClanarine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataClanarine = await _context.NaplataClanarina
                .Include(n => n.Clanarina)
                .Include(n => n.Upravnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naplataClanarine == null)
            {
                return NotFound();
            }

            return View(naplataClanarine);
        }

        // GET: NaplataClanarine/Create
        public IActionResult Create()
        {
            ViewData["ClanarinaId"] = new SelectList(_context.Clanarine, "Id", "NazivClanarine");
            ViewData["UpravnikId"] = new SelectList(_context.Upravnici, "Id", "FullName");
            return View();
        }

        // POST: NaplataClanarine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UpravnikId,ClanarinaId")] NaplataClanarine naplataClanarine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naplataClanarine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanarinaId"] = new SelectList(_context.Clanarine, "Id", "NazivClanarine", naplataClanarine.ClanarinaId);
            ViewData["UpravnikId"] = new SelectList(_context.Upravnici, "Id", "FullName", naplataClanarine.UpravnikId);
            return View(naplataClanarine);
        }

        // GET: NaplataClanarine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataClanarine = await _context.NaplataClanarina.FindAsync(id);
            if (naplataClanarine == null)
            {
                return NotFound();
            }
            ViewData["ClanarinaId"] = new SelectList(_context.Clanarine, "Id", "NazivClanarine", naplataClanarine.ClanarinaId);
            ViewData["UpravnikId"] = new SelectList(_context.Upravnici, "Id", "FullName", naplataClanarine.UpravnikId);
            return View(naplataClanarine);
        }

        // POST: NaplataClanarine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UpravnikId,ClanarinaId")] NaplataClanarine naplataClanarine)
        {
            if (id != naplataClanarine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naplataClanarine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaplataClanarineExists(naplataClanarine.Id))
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
            ViewData["ClanarinaId"] = new SelectList(_context.Clanarine, "Id", "NazivClanarine", naplataClanarine.ClanarinaId);
            ViewData["UpravnikId"] = new SelectList(_context.Upravnici, "Id", "FullName", naplataClanarine.UpravnikId);
            return View(naplataClanarine);
        }

        // GET: NaplataClanarine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naplataClanarine = await _context.NaplataClanarina
                .Include(n => n.Clanarina)
                .Include(n => n.Upravnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naplataClanarine == null)
            {
                return NotFound();
            }

            return View(naplataClanarine);
        }

        // POST: NaplataClanarine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naplataClanarine = await _context.NaplataClanarina.FindAsync(id);
            _context.NaplataClanarina.Remove(naplataClanarine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaplataClanarineExists(int id)
        {
            return _context.NaplataClanarina.Any(e => e.Id == id);
        }
    }
}
