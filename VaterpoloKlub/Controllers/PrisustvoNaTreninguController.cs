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
            var result = await _context.Treninzi.ToListAsync();
            ViewData["Treninzi"] = result;
            return View();
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
                .Where(m => m.TreningId == id).ToListAsync();
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }
            ViewBag.treningId = id;
            ViewBag.nesto = prisustvoNaTreningu;
            return View();
        }

        // GET: PrisustvoNaTreningu/Create
        public async Task<IActionResult> Create() // id == treningId
        {
            ViewData["TreningId"] = new SelectList(_context.Treninzi, "Id", "Id");
            return View();
        }

        // POST: PrisustvoNaTreningu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? TreningId)
        {
            var result = await _context.PrisustvoNaTreninzima.Where(x => x.TreningId == TreningId).ToListAsync();
            if (result.Count != 0)
            {
                return RedirectToAction(nameof(Edit), new { id = TreningId });
            }
            var igraci = await _context.Clanovi.ToListAsync();
            foreach (var item in igraci)
            {
                await _context.AddAsync(new PrisustvoNaTreningu { ClanId = item.ID, TreningId = (int)TreningId, Prisutan = false });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = TreningId });
        }

        // GET: PrisustvoNaTreningu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _context.PrisustvoNaTreninzima.Where(x => x.TreningId == id).ToListAsync();
            if (result.Count == 0)
            {
                return await Create(id);
            }
            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima.Include(p => p.Clan).Include(p => p.Trening).Where(x => x.TreningId == id).ToListAsync();
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }
            ViewData["nesto"] = prisustvoNaTreningu;
            return View();
        }

        // POST: PrisustvoNaTreningu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, List<int> Prisustvo)
        {
            if(id == null)
            {
                return NotFound();
            }
            var clanoviPrisustvo = await _context.PrisustvoNaTreninzima.Where(x => x.TreningId == id).ToListAsync();
            foreach (var item in clanoviPrisustvo)
            {
                if (Prisustvo.IndexOf(item.ClanId) > -1 && !item.Prisutan)
                {
                    item.Prisutan = true;
                    _context.Update(item);                }
                if (item.Prisutan && Prisustvo.IndexOf(item.ClanId) < 0)
                {
                    item.Prisutan = false;
                    _context.Update(item);                
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PrisustvoNaTreningu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _context.PrisustvoNaTreninzima.Where(x => x.TreningId == id).ToListAsync();
            if (result.Count == 0)
            {
                return await Create(id);
            }
            var prisustvoNaTreningu = await _context.PrisustvoNaTreninzima
                .Include(p => p.Clan)
                .Include(p => p.Trening)
                .Where(x => x.TreningId == id)
                .ToListAsync();
            if (prisustvoNaTreningu == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: PrisustvoNaTreningu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _context.PrisustvoNaTreninzima.Where(x => x.TreningId == id).ToListAsync();
            foreach(var item in result)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisustvoNaTreninguExists(int id)
        {
            return _context.PrisustvoNaTreninzima.Any(e => e.TreningId == id);
        }
    }
}
