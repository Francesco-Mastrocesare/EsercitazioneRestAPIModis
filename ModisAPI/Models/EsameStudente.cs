using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class EsameStudente
    {
        public int EsameId { get; set; }
        public Esame Esame { get; set; }

        public int Voto { get; set; }
        public int StudenteId { get; set; }
        public Studente Studente { get; set; }

    }
}
