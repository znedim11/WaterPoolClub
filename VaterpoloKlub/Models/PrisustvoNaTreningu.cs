namespace VaterpoloKlub.Models
{
    public class PrisustvoNaTreningu
    {
        public int TreningId { get; set; }
        public Trening Trening { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }
        public bool Prisutan { get; set; }

    }
}