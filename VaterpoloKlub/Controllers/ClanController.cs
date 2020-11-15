using Microsoft.AspNetCore.Mvc;
using VaterpoloKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaterpoloKlub.Data;
using Sprint1.EF;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VaterpoloKlub.Controllers
{
   
    public class ClanController:Controller
    {

        public IActionResult View(string q)
        {

            SprintDbContext db = new SprintDbContext();

            List<Clan> clanovi = db.Clan
                .Where(s => q == null || (s.Ime + " " + s.Prezime).ToLower().StartsWith(q.ToLower()) ||
                            (s.Prezime + " " + s.Ime).ToLower().StartsWith(q.ToLower()))
                .ToList();

            ViewData["q"] = q;
            ViewData["clanovi"] = clanovi;


            return View();
        }

        
        public IActionResult Add()
                {
                    SprintDbContext db = new SprintDbContext();
                    List<Clan> clanovi = db.Clan
                        .ToList();

                    ViewData["clanovi"] = clanovi;
                    return View("Add");
                }
            
        public IActionResult Edit(int clanID)
        {
            SprintDbContext db = new SprintDbContext();
            //List<Clan> clanovi = db.Clan
            //    .OrderBy(a => a.Ime)
            //    .ToList();

            //ViewData["clanovi"] = clanovi;

            Clan c = clanID == 0 ? new Clan() : db.Clan.Find(clanID);
            ViewData["clanEdit"] = c;

            return View("Edit");
        }
       
        public IActionResult Save(int clanID,string ime, string prezime, string adresa, string mjesto, string kontakt, string email)
        {
            
                SprintDbContext db = new SprintDbContext();
                Clan clan;
               


            if (clanID == 0)
                {
                    clan = new Clan();
                foreach (var e in db.Clan)
                {
                    if(e.Email==email)
                    return Json($"Email ({email}) se vec koristi");
                    if(e.Kontakt==kontakt)
                        return Json($"Kontakt broj ({kontakt}) se vec koristi");
                }

                db.Add(clan);
                }
                else
                {
                    clan = db.Clan.Find(clanID);
                foreach (var e in db.Clan)
                {
                    if (e.ID != clanID)
                    {
                        if (e.Email == email)
                            return Json($"Email ({email}) se vec koristi");
                        if (e.Kontakt == kontakt)
                            return Json($"Kontakt broj ({kontakt}) se vec koristi");
                    }
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
            SprintDbContext db = new SprintDbContext();
            Clan s = db.Clan.Find(ClanID);

            db.Remove(s);
            db.SaveChanges();


            return Redirect("/Clan/View");
        }
    }
}
