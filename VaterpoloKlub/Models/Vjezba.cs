using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class Vjezba
    {
        public int Id { get; set; }
        public string NazivVjezbe { get; set; }
        public string MjernaJedinica { get; set; }
        public List<RezultatTestiranja> RezultatiTestiranja { get; set; }
    }
}
