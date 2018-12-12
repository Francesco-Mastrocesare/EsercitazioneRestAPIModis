using System.Collections.Generic;
using ModisAPI.Models;
using ModisAPI.ViewModels;

namespace ModisAPI.WorkerServices
{
    public interface IWorkerServiceStudenti
    {
        List<ViewModelStudente> RestituisciListaStudenti();
        List<ViewModelStudente> RestituisciStudente(int id);
        void CreaStudente(Studente studente);
        void ModificaStudente(Studente studenteModificato);
        void CancellaStudente(int id);
    }
}