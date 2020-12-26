using System;
using System.ComponentModel;

namespace VaterpoloKlub.Models
{
    public class Clanarina 
    {
        public int Id { get; set; }
        [DisplayName("Datum pocetka")]
        public DateTime DatumPocketa { get; set; }
        [DisplayName("Datum kraja")]
        public DateTime DatumKraja { get; set; }
        [DisplayName("Clan")]
        public int ClanId { get; set; }
        public Clan Clan { get; set; }

    }
}