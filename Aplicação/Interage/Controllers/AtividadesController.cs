using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Interage.Models;
using Interage.DTO;

namespace Interage.Controllers
{
    public class AtividadesController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Atividades
        public IEnumerable<AtividadeDTO> GetAtividade()
        {
            return db.Atividade.ToList()
                .Select(x => new AtividadeDTO(x));
        }

        // GET: api/Atividades/5
        [ResponseType(typeof(AtividadeDTO))]
        public IHttpActionResult GetAtividade(int id)
        {
            Atividade atividade = db.Atividade.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            return Ok(new AtividadeDTO(atividade));
        }

        // PUT: api/Atividades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtividade(int id, Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atividade.Codigo)
            {
                return BadRequest();
            }

            db.Entry(atividade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Atividades
        [ResponseType(typeof(AtividadeDTO))]
        public IHttpActionResult PostAtividade(Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atividade.Add(atividade);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return CreatedAtRoute("DefaultApi", new { id = atividade.Codigo }, new AtividadeDTO(atividade));
        }

        // DELETE: api/Atividades/5
        [ResponseType(typeof(AtividadeDTO))]
        public IHttpActionResult DeleteAtividade(int id)
        {
            Atividade atividade = db.Atividade.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            AtividadeDTO a = new AtividadeDTO(atividade);
            db.Atividade.Remove(atividade);
            db.SaveChanges();

            return Ok(a);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtividadeExists(int id)
        {
            return db.Atividade.Count(e => e.Codigo == id) > 0;
        }
    }
}