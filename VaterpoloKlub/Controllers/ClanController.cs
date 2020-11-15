using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VaterpoloKlub.Data;
using VaterpoloKlub.Models;

namespace VaterpoloKlub.Controllers
{
    public class ClanController : Controller
    {
        private readonly ApplicationDbContext db;

        public ClanController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IActionResult View(string q)
        {
            var clanovi = db.Clanovi
                .Where(s => q == null || (s.Ime + " " + s.Prezime).ToLower().StartsWith(q.ToLower()) ||
                            (s.Prezime + " " + s.Ime).ToLower().StartsWith(q.ToLower()))
                .ToList();

            ViewData["q"] = q;
            ViewData["clanovi"] = clanovi;


            return View();
        }


        public IActionResult Add()
        {
            var clanovi = db.Clanovi
                .ToList();

            ViewData["clanovi"] = clanovi;
            return View("Add");
        }

        public IActionResult Edit(int clanID)
        {
            //List<Clan> clanovi = db.Clanovi
            //    .OrderBy(a => a.Ime)
            //    .ToList();

            //ViewData["clanovi"] = clanovi;

            var c = clanID == 0 ? new Clan() : db.Clanovi.Find(clanID);
            ViewData["clanEdit"] = c;

            return View("Edit");
        }

        public IActionResult Save(int clanID, string ime, string prezime, string adresa, string mjesto, string kontakt,
            string email)
        {
            Clan clan;


            if (clanID == 0)
            {
                clan = new Clan();
                foreach (var e in db.Clanovi)
                {
                    if (e.Email == email)
                        return Json($"Email ({email}) se vec koristi");
                    if (e.Kontakt == kontakt)
                        return Json($"Kontakt broj ({kontakt}) se vec koristi");
                }

                db.Add(clan);
            }
            else
            {
                clan = db.Clanovi.Find(clanID);
                foreach (var e in db.Clanovi)
                    if (e.ID != clanID)
                    {
                        if (e.Email == email)
                            return Json($"Email ({email}) se vec koristi");
                        if (e.Kontakt == kontakt)
                            return Json($"Kontakt broj ({kontakt}) se vec koristi");
                    }
            }

            clan.Ime = ime;
            clan.Prezime = prezime;
            clan.Adresa = adresa;
            clan.Mjesto = mjesto;
            clan.Kontakt = kontakt;
            clan.Email = email;
            clan.Datum = DateTime.Now;


            db.SaveChanges();


            return Redirect("/Clan/View");
        }

        public IActionResult Delete(int ClanID)
        {
            var s = db.Clanovi.Find(ClanID);

            db.Remove(s);
            db.SaveChanges();


            return Redirect("/Clan/View");
        }
    }
}