using System.Collections.Generic;
using ModisAPI.Models;

namespace ModisAPI.WorkerServices
{
    public interface IWorkerServiceCorso
    {
        List<Corso> RestituisciListaCorsi();
        Corso RestituisciCorso(int id);
        void CreaCorso(Corso corso);
        void ModificaCorso(Corso corsoModificato);
        void CancellaCorso(int id);
    }
}