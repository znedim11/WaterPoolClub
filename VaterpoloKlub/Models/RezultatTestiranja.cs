using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class RezultatTestiranja
    {
        public int TestiranjeId { get; set; }
        public int VjezbaId { get; set; }

        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public VjezbeTestiranje VjezbeTestiranje { get; set; }
        public string Rezultat { get; set; }
    }
}
