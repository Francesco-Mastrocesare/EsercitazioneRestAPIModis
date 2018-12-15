using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModisAPI.Models;
using ModisAPI.WorkerServices;

namespace ModisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorsiController : ControllerBase
    {
        private readonly IWorkerServiceCorso worker;
        public CorsiController(IWorkerServiceCorso _worker)
        {
           worker = _worker;
        }

        // GET: api/Corsi
        [HttpGet]
        public IEnumerable<Corso> GetCorsi()
        {
            return worker.RestituisciListaCorsi();
        }

        // GET: api/Corsi/5
        [HttpGet("{id}", Name = "GetCorso")]
        public Corso GetCorso(int id)
        {
            return worker.RestituisciCorso(id);
        }

        // POST: api/Corsi
        [HttpPost]
        public void Post(Corso corso)
        {
            worker.CreaCorso(corso);
        }

        // PUT: api/Corsi/5
        [HttpPut("{id}")]
        public void Put(int id, Corso corsoModificato)
        {
            worker.ModificaCorso(corsoModificato);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            worker.CancellaCorso(id);
        }
    }
}
