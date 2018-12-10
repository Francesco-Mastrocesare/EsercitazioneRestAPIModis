using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class StudenteCorso
    {
        public int StudenteId { get; set; }
        public Studente Studente { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
    }
}
