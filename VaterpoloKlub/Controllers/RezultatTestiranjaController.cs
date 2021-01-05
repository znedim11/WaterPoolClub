using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Data;
using VaterpoloKlub.Models;
using VaterpoloKlub.ViewModels;

namespace VaterpoloKlub.Controllers
{
    public class RezultatTestiranjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezultatTestiranjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        // GET: RezultatTestiranja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultatTestiranja = await _context.Clanovi.Include(x => x.RezultatiTestiranja).ToListAsync();
            List<Clan> temp = new List<Clan>();
            foreach (var clan in rezultatTestiranja)
            {
                clan.RezultatiTestiranja = clan.RezultatiTestiranja.Where(x => x.TestiranjeId == id).ToList();
                if (clan.RezultatiTestiranja.Count > 0) temp.Add(clan);
            }
            if (rezultatTestiranja == null)
            {
                return NotFound();
            }
            var vjezbeTestiranje = await _context.VjezbeTestiranje.Include(x => x.Vjezba).Where(x => x.TestiranjeId == id).ToListAsync();
            var nesto = new RezultatTestiranjaViewModel
            {
                Clanovi = temp,
                VjezbeTestiranje = vjezbeTestiranje
            };
            //ViewData["rezTestiranja"] = rezultatTestiranja;
            //ViewData["vjTestiranja"] = vjezbeTestiranje;
            return View(nesto);
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
            var nesto = new RezultatTestiranjaViewModel
            {
                Clanovi = rezultatTestiranja,
                VjezbeTestiranje = vjezbeTestiranje
            };
            //ViewData["rezTestiranja"] = rezultatTestiranja;
            //ViewData["vjTestiranja"] = vjezbeTestiranje;
            return View(nesto);
        }

        // POST: RezultatTestiranja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RezultatTestiranjaViewModel nesto)
        {
            foreach (var item in nesto.Clanovi)
            {
                _context.Update(item);
            }
            await _context.SaveChangesAsync();
            return Redirect("/Testiranje/Index");
        }
                
        private bool RezultatTestiranjaExists(int id)
        {
            return _context.RezultatiTestiranja.Any(e => e.ClanId == id);
        }
    }
}
