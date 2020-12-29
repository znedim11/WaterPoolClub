using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class VjezbeTestiranje
    {
        public Vjezba Vjezba { get; set; }
        public int VjezbaId { get; set; }
        public Testiranje Testiranje { get; set; }
        public int TestiranjeId { get; set; }
        public List<RezultatTestiranja> RezultatTestiranja { get; set; }
    }
}
