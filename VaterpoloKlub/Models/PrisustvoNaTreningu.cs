namespace VaterpoloKlub.Models
{
    public class PrisustvoNaTreningu
    {
        public int Id { get; set; }
        public int TreningId { get; set; }
        public Trening Trening { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; }

    }
}