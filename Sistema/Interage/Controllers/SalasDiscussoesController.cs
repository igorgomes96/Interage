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

namespace Interage.Controllers
{
    public class SalasDiscussoesController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/SalasDiscussoes
        public IQueryable<SalaDiscussao> GetSalaDiscussao()
        {
            return db.SalaDiscussao;
        }

        // GET: api/SalasDiscussoes/5
        [ResponseType(typeof(SalaDiscussao))]
        public IHttpActionResult GetSalaDiscussao(int id)
        {
            SalaDiscussao salaDiscussao = db.SalaDiscussao.Find(id);
            if (salaDiscussao == null)
            {
                return NotFound();
            }

            return Ok(salaDiscussao);
        }

        // PUT: api/SalasDiscussoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalaDiscussao(int id, SalaDiscussao salaDiscussao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salaDiscussao.Codigo)
            {
                return BadRequest();
            }

            db.Entry(salaDiscussao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaDiscussaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SalasDiscussoes
        [ResponseType(typeof(SalaDiscussao))]
        public IHttpActionResult PostSalaDiscussao(SalaDiscussao salaDiscussao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalaDiscussao.Add(salaDiscussao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SalaDiscussaoExists(salaDiscussao.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = salaDiscussao.Codigo }, salaDiscussao);
        }

        // DELETE: api/SalasDiscussoes/5
        [ResponseType(typeof(SalaDiscussao))]
        public IHttpActionResult DeleteSalaDiscussao(int id)
        {
            SalaDiscussao salaDiscussao = db.SalaDiscussao.Find(id);
            if (salaDiscussao == null)
            {
                return NotFound();
            }

            db.SalaDiscussao.Remove(salaDiscussao);
            db.SaveChanges();

            return Ok(salaDiscussao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaDiscussaoExists(int id)
        {
            return db.SalaDiscussao.Count(e => e.Codigo == id) > 0;
        }
    }
}