using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModisAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ModisAPI.WorkerServices
{
    public class WorkerServiceSQLServerDB : IWorkerServiceStudenti
    {
        private ModisContext db;
        public WorkerServiceSQLServerDB(ModisContext _db)
        {
            db = _db;
        }

        public List<ViewModelStudente> RestituisciListaStudenti()
        {
            return db.Studenti.Include("Corsi").
                Select(y => new ViewModelStudente
                {
                    Id = y.Id,
                    NomeCompleto = y.Nome + " " + y.Cognome,
                    Corsi = y.StudenteCorsi.Select(
                        z => new Corso {
                            CorsoId = z.Corso.CorsoId,
                            DataInizio = z.Corso.DataInizio,
                            Livello = z.Corso.Livello,
                            NumeroMassimoPartecipanti = z.Corso.NumeroMassimoPartecipanti,
                            DurataInOre = z.Corso.DurataInOre,
                            Nome = z.Corso.Nome
                        }).ToList()
                }).ToList();
        }

        public List<ViewModelStudente> RestituisciStudente(int id)
        {
            //oppure -> db.Studenti.Find(id);
            return db.Studenti.Where(x => x.Id == id).Include("Corsi").
                Select(y => new ViewModelStudente
                {
                    Id = y.Id,
                    NomeCompleto = y.Nome + " " + y.Cognome,
                    Corsi = y.StudenteCorsi.Select(
                        z => new Corso {
                            CorsoId = z.Corso.CorsoId,
                            DataInizio = z.Corso.DataInizio,
                            Livello = z.Corso.Livello,
                            NumeroMassimoPartecipanti = z.Corso.NumeroMassimoPartecipanti,
                            DurataInOre = z.Corso.DurataInOre,
                            Nome = z.Corso.Nome
                        }).ToList()
                }).ToList();
        }

        public void CreaStudente(Studente studente)
        {
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            db.Entry(studenteModificato).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void CancellaStudente(int id)
        {
            var studente = db.Studenti.Find(id);
            if (studente != null)
            {
                db.Entry(studente).State = 
                    Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}

//    public class WorkerServiceOracleDb : IWorkerServiceStudenti
//    {
//        public void CreaStudente(Studente studente)
//        {
//            throw new NotImplementedException();
//        }

//        public void ModificaStudente(Studente studenteModificato)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Studente> RestituisciListaStudenti()
//        {
//            throw new NotImplementedException();
//        }

//        public Studente RestituisciStudente(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class WorkerServiceStudenti : IWorkerServiceStudenti
//    {
//        public void CreaStudente(Studente studente)
//        {
//            throw new NotImplementedException();
//        }

//        public void ModificaStudente(Studente studenteModificato)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Studente> RestituisciListaStudenti()
//        {
//            var studente1 = new Studente { Id = 1, Cognome = "Mario", Nome = "Rossi" };
//            var studente2 = new Studente { Id = 2, Cognome = "MastroCesare", Nome = "Francesco" };
//            return new List<Studente> { studente1, studente2 };
//        }

//        public Studente RestituisciStudente(int id)
//        {
//            return RestituisciListaStudenti().Where(x => x.Id == id).FirstOrDefault();
//        }

//    }
//}
