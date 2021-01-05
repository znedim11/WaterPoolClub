using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class Clan
    {
     
        public string Ime { get; set; }
        public string  Prezime { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public DateTime Datum { get; set; }
        public string Kontakt { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public List<PrisustvoNaTreningu> PrisustvoNaTreningu { get; set; }
        public List<RezultatTestiranja> RezultatiTestiranja { get; set; }
        public List<ClanUEkipi> ClanUEkipi { get; set; }

    }
}
