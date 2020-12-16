using System.Collections.Generic;

namespace VaterpoloKlub.Models
{
    public class Trening
    {
        public int Id { get; set; }
        public int TrenerId { get; set; }
        public int BazenId { get; set; }
        public List<PrisustvoNaTreningu> PrisustvoNaTreningu{ get; set; }

    }
}