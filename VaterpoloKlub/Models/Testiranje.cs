using System;
using System.Collections.Generic;

namespace VaterpoloKlub.Models
{
    public class Testiranje
    {
        public int Id { get; set; }
        public int TrenerId { get; set; }
        public Trener Trener { get; set; }
        public DateTime DatumTestiranja { get; set; }
        public string NazivTestiranja { get; set; }
        public List<RezultatTestiranja> RezultatiTestiranja { get; set; }
    }
}