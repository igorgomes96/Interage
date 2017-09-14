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
    public class SalasDiscussoesController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/SalasDiscussoes
        public IEnumerable<SalaDiscussaoDTO> GetSalaDiscussao()
        {
            return db.SalaDiscussao.ToList()
                .Select(x => new SalaDiscussaoDTO(x));
        }

        // GET: api/SalasDiscussoes/5
        [ResponseType(typeof(SalaDiscussaoDTO))]
        public IHttpActionResult GetSalaDiscussao(int id)
        {
            SalaDiscussao salaDiscussao = db.SalaDiscussao.Find(id);
            if (salaDiscussao == null)
            {
                return NotFound();
            }

            return Ok(new SalaDiscussaoDTO(salaDiscussao));
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SalasDiscussoes
        [ResponseType(typeof(SalaDiscussaoDTO))]
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
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return CreatedAtRoute("DefaultApi", new { id = salaDiscussao.Codigo }, new SalaDiscussaoDTO(salaDiscussao));
        }

        // DELETE: api/SalasDiscussoes/5
        [ResponseType(typeof(SalaDiscussaoDTO))]
        public IHttpActionResult DeleteSalaDiscussao(int id)
        {
            SalaDiscussao salaDiscussao = db.SalaDiscussao.Find(id);
            if (salaDiscussao == null)
            {
                return NotFound();
            }

            SalaDiscussaoDTO s = new SalaDiscussaoDTO(salaDiscussao);
            db.SalaDiscussao.Remove(salaDiscussao);
            db.SaveChanges();

            return Ok(s);
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