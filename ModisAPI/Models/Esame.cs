using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class Esame
    {
        public int EsameId {get; set;}
        
        public int Durata { get; set; }
        public DateTime DataEsame { get; set; }
        public string LuogoEsame { get; set; }

        public IList<EsameStudente> EsameStudenti { get; set; }
    }
}
