using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class Corso
    {
        public int CorsoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInizio { get; set; }
        public int DurataInOre { get; set; }
        public int Livello { get; set; }
        public int NumeroMassimoPartecipanti { get; set; }
    }
}
