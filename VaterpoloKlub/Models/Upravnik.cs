namespace VaterpoloKlub.Models
{
    public class Upravnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }

        public int KontaktBroj { get; set; }
        public string FullName
        {
            get
            {
                return Ime + " " + Prezime;
            }
        }


    }
}