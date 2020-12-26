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
    public class VjezbaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VjezbaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vjezba
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vjezbe.ToListAsync());
        }

        // GET: Vjezba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezbe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vjezba == null)
            {
                return NotFound();
            }

            return View(vjezba);
        }

        // GET: Vjezba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vjezba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivVjezbe,MjernaJedinica")] Vjezba vjezba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vjezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vjezba);
        }

        // GET: Vjezba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezbe.FindAsync(id);
            if (vjezba == null)
            {
                return NotFound();
            }
            return View(vjezba);
        }

        // POST: Vjezba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivVjezbe,MjernaJedinica")] Vjezba vjezba)
        {
            if (id != vjezba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vjezba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VjezbaExists(vjezba.Id))
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
            return View(vjezba);
        }

        // GET: Vjezba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezbe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vjezba == null)
            {
                return NotFound();
            }

            return View(vjezba);
        }

        // POST: Vjezba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vjezba = await _context.Vjezbe.FindAsync(id);
            _context.Vjezbe.Remove(vjezba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VjezbaExists(int id)
        {
            return _context.Vjezbe.Any(e => e.Id == id);
        }
    }
}
