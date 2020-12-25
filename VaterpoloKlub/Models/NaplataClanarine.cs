namespace VaterpoloKlub.Models
{
    public class NaplataClanarine
    {
        public int Id { get; set; }

        public int UpravnikId { get; set; }
        public Upravnik Upravnik { get; set; }
        public int ClanarinaId { get; set; }

        public Clanarina Clanarina { get; set; }

    }
}