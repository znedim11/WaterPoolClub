using System.Collections.Generic;

namespace VaterpoloKlub.Models
{
    public class Ekipa
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<ClanUEkipi> Clanovi { get; set; }

    }
}