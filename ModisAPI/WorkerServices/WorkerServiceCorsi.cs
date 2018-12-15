using Microsoft.EntityFrameworkCore;
using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.WorkerServices
{
    public class WorkerServiceSQLServerDbCorsi : IWorkerServiceCorso
    {
        private ModisContext db;

        public WorkerServiceSQLServerDbCorsi(ModisContext _db)
        {
            db = _db;
        }

        public void CancellaCorso(int id)
        {
            db.Entry(RestituisciCorso(id)).State = 
                Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public void CreaCorso(Corso corso)
        {
            db.Corsi.Add(corso);
            db.SaveChanges();
        }

        public void ModificaCorso(Corso corsoModificato)
        {
            db.Entry(corsoModificato).State = 
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public Corso RestituisciCorso(int id)
        {
            return db.Corsi.Where(corso => corso.CorsoId == id).FirstOrDefault();
        }

        public List<Corso> RestituisciListaCorsi()
        {
            return db.Corsi.ToList();
        }
    }
}
