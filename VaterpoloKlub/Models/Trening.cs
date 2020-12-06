using System;

namespace VaterpoloKlub.Models
{
    public class Trening
    {
        public int ID { get; set; }

        public DateTime Datum { get; set; }

        public int TrenerID { get; set; }

        public Trener Trener { get; set; }

        public int BazenID { get; set; }

        public Bazen Bazen { get; set; }

        public int VrstaTreningaID { get; set; }

        public VrstaTreninga VrstaTreninga { get; set; }

    }
}