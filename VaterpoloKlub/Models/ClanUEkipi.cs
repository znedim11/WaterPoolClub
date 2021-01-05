namespace VaterpoloKlub.Models
{
    public class ClanUEkipi
    {
        public int EkipaId { get; set; }
        public Ekipa Ekipa { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }

    }
}