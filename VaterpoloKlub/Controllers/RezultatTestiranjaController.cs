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
    public class RezultatTestiranjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezultatTestiranjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RezultatTestiranja
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RezultatiTestiranja.Include(r => r.Clan).Include(r => r.VjezbeTestiranje);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RezultatTestiranja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultatTestiranja = await _context.RezultatiTestiranja
                .Include(r => r.Clan)
                .Include(r => r.VjezbeTestiranje)
                .FirstOrDefaultAsync(m => m.ClanId == id);
            if (rezultatTestiranja == null)
            {
                return NotFound();
            }

            return View(rezultatTestiranja);
        }

        // GET: RezultatTestiranja/Create
        public IActionResult Create()
        {
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID");
            ViewData["VjezbaId"] = new SelectList(_context.VjezbeTestiranje, "TestirajeId", "TestirajeId");
            return View();
        }

        // POST: RezultatTestiranja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestiranjeId,VjezbaId,ClanId,Rezultat")] RezultatTestiranja rezultatTestiranja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezultatTestiranja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", rezultatTestiranja.ClanId);
            ViewData["VjezbaId"] = new SelectList(_context.VjezbeTestiranje, "TestirajeId", "TestirajeId", rezultatTestiranja.VjezbaId);
            return View(rezultatTestiranja);
        }

        // GET: RezultatTestiranja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultatTestiranja = await _context.Clanovi.Include(x => x.RezultatiTestiranja).ToListAsync();
            List<RezultatTestiranja> temp = new List<RezultatTestiranja>();
            foreach (var clan in rezultatTestiranja)
            {
                clan.RezultatiTestiranja = clan.RezultatiTestiranja.Where(x => x.TestiranjeId == id).ToList();
            }
            if (rezultatTestiranja == null)
            {
                return NotFound();
            }
            var vjezbeTestiranje = await _context.VjezbeTestiranje.Include(x => x.Vjezba).Where(x => x.TestiranjeId == id).ToListAsync();
            ViewData["rezTestiranja"] = rezultatTestiranja;
            ViewData["vjTestiranja"] = vjezbeTestiranje;
            return View();
        }

        // POST: RezultatTestiranja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestiranjeId,VjezbaId,ClanId,Rezultat")] RezultatTestiranja rezultatTestiranja)
        {
            if (id != rezultatTestiranja.ClanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezultatTestiranja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezultatTestiranjaExists(rezultatTestiranja.ClanId))
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
            ViewData["ClanId"] = new SelectList(_context.Clanovi, "ID", "ID", rezultatTestiranja.ClanId);
            ViewData["VjezbaId"] = new SelectList(_context.VjezbeTestiranje, "TestirajeId", "TestirajeId", rezultatTestiranja.VjezbaId);
            return View(rezultatTestiranja);
        }

        // GET: RezultatTestiranja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultatTestiranja = await _context.RezultatiTestiranja
                .Include(r => r.Clan)
                .Include(r => r.VjezbeTestiranje)
                .FirstOrDefaultAsync(m => m.ClanId == id);
            if (rezultatTestiranja == null)
            {
                return NotFound();
            }

            return View(rezultatTestiranja);
        }

        // POST: RezultatTestiranja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezultatTestiranja = await _context.RezultatiTestiranja.FindAsync(id);
            _context.RezultatiTestiranja.Remove(rezultatTestiranja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezultatTestiranjaExists(int id)
        {
            return _context.RezultatiTestiranja.Any(e => e.ClanId == id);
        }
    }
}
