using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaterpoloKlub.Models
{
    public class Trener
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }

}
