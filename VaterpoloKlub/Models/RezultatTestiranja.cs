using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class RezultatTestiranja
    {
        public int TestiranjeId { get; set; }
        public Testiranje Testiranje { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public int VjezbaId { get; set; }
        public Vjezba Vjezba { get; set; }
        public string Rezultat { get; set; }
    }
}
