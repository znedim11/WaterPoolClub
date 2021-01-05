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
    public class EkipaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EkipaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ekipa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ekipe.ToListAsync());
        }

        // GET: Ekipa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekipa = await _context.Ekipe.Include(x=>x.Clanovi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekipa == null)
            {
                return NotFound();
            }
            foreach (var item in ekipa.Clanovi)
            {
                item.Clan = await _context.Clanovi.FindAsync(item.ClanId);
            }
            return View(ekipa);
        }

        // GET: Ekipa/Create
        public IActionResult Create()
        {
            var result = _context.Clanovi.ToList();
            ViewData["Clanovi"] = result;
            return View();
        }

        // POST: Ekipa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Ekipa ekipa, List<int> Igraci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekipa);
                await _context.SaveChangesAsync();
                foreach (var item in Igraci)
                {
                    _context.Add(new ClanUEkipi { ClanId = item, EkipaId = ekipa.Id });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ekipa);
        }

        // GET: Ekipa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var ekipa = await _context.Ekipe.Include(x=>x.Clanovi).FirstAsync(x => x.Id == id);
            //if (ekipa == null)
            //{
            //    return NotFound();
            //}
            //return View(ekipa);
            if (id == null)
            {
                return NotFound();
            }

            var ekipa = await _context.Ekipe.Include(x => x.Clanovi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekipa == null)
            {
                return NotFound();
            }
            foreach (var item in ekipa.Clanovi)
            {
                item.Clan = await _context.Clanovi.FindAsync(item.ClanId);
            }
            ViewData["Clanovi"] = await _context.Clanovi.ToListAsync();
            return View(ekipa);
        }

        // POST: Ekipa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Ekipa ekipa, List<int> Igraci)
        {
            if (id != ekipa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ekipa.Clanovi = await _context.ClanUEkipama.Where(x => x.EkipaId == id).ToListAsync();
                    for (int i = 0; i < ekipa.Clanovi.Count; i++)
                    {
                        if (ekipa.Clanovi[i].ClanId != Igraci[i])
                        {
                            _context.ClanUEkipama.Remove(ekipa.Clanovi[i]);
                            await _context.SaveChangesAsync();
                            _context.ClanUEkipama.Add( new ClanUEkipi { ClanId = Igraci[i], EkipaId = id });
                        }
                    }
                    _context.Update(ekipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkipaExists(ekipa.Id))
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
            return View(ekipa);
        }

        // GET: Ekipa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekipa = await _context.Ekipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekipa == null)
            {
                return NotFound();
            }

            return View(ekipa);
        }

        // POST: Ekipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ekipa = await _context.Ekipe.FindAsync(id);
            _context.Ekipe.Remove(ekipa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EkipaExists(int id)
        {
            return _context.Ekipe.Any(e => e.Id == id);
        }
    }
}
