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
    public class PrisustvoNaTreninguController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrisustvoNaTreninguController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrisustvoNaTreningu
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrisustvoNaTreninzima.Include(p => p.Clan).Include(p => p.Trening);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrisustvoNaTreningu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima
                .Include(p => p.Clan)
                .Include(p => p.Trening)
                .FirstOrDefaultAsync(m => m.TreningId == id);
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }

            return View(prisustvoNaTreningu);
        }

        // GET: PrisustvoNaTreningu/Create
        public IActionResult Create()
        {
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID");
            ViewData["TreningId"] = new SelectList(_context.Treninzi, "Id", "Id");
            return View();
        }

        // POST: PrisustvoNaTreningu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreningId,ClanId")] PrisustvoNaTreningu prisustvoNaTreningu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prisustvoNaTreningu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", prisustvoNaTreningu.ClanId);
            ViewData["TreningId"] = new SelectList(_context.Treninzi, "Id", "Id", prisustvoNaTreningu.TreningId);
            return View(prisustvoNaTreningu);
        }

        // GET: PrisustvoNaTreningu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima.FindAsync(id);
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", prisustvoNaTreningu.ClanId);
            ViewData["TreningId"] = new SelectList(_context.Treninzi, "Id", "Id", prisustvoNaTreningu.TreningId);
            return View(prisustvoNaTreningu);
        }

        // POST: PrisustvoNaTreningu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreningId,ClanId")] PrisustvoNaTreningu prisustvoNaTreningu)
        {
            if (id != prisustvoNaTreningu.TreningId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prisustvoNaTreningu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrisustvoNaTreninguExists(prisustvoNaTreningu.TreningId))
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
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", prisustvoNaTreningu.ClanId);
            ViewData["TreningId"] = new SelectList(_context.Treninzi, "Id", "Id", prisustvoNaTreningu.TreningId);
            return View(prisustvoNaTreningu);
        }

        // GET: PrisustvoNaTreningu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima
                .Include(p => p.Clan)
                .Include(p => p.Trening)
                .FirstOrDefaultAsync(m => m.TreningId == id);
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }

            return View(prisustvoNaTreningu);
        }

        // POST: PrisustvoNaTreningu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima.FindAsync(id);
            _context.PrisustvoNaTreninzima.Remove(prisustvoNaTreningu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisustvoNaTreninguExists(int id)
        {
            return _context.PrisustvoNaTreninzima.Any(e => e.TreningId == id);
        }
    }
}
