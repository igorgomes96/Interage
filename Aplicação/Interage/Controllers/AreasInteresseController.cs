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
    public class AreasInteresseController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/AreasInteresse
        public IEnumerable<AreaInteresseDTO> GetAreaInteresse()
        {
            return db.AreaInteresse.ToList()
                .Select(x => new AreaInteresseDTO(x));
        }

        // GET: api/AreasInteresse/5
        [ResponseType(typeof(AreaInteresseDTO))]
        public IHttpActionResult GetAreaInteresse(int id)
        {
            AreaInteresse areaInteresse = db.AreaInteresse.Find(id);
            if (areaInteresse == null)
            {
                return NotFound();
            }

            return Ok(new AreaInteresseDTO(areaInteresse));
        }

        // PUT: api/AreasInteresse/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAreaInteresse(int id, AreaInteresse areaInteresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != areaInteresse.Codigo)
            {
                return BadRequest();
            }

            db.Entry(areaInteresse).State = EntityState.Modified;

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

        // POST: api/AreasInteresse
        [ResponseType(typeof(AreaInteresseDTO))]
        public IHttpActionResult PostAreaInteresse(AreaInteresse areaInteresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AreaInteresse.Add(areaInteresse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AreaInteresseExists(areaInteresse.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = areaInteresse.Codigo }, new AreaInteresseDTO(areaInteresse));
        }

        // DELETE: api/AreasInteresse/5
        [ResponseType(typeof(AreaInteresseDTO))]
        public IHttpActionResult DeleteAreaInteresse(int id)
        {
            AreaInteresse areaInteresse = db.AreaInteresse.Find(id);
            if (areaInteresse == null)
            {
                return NotFound();
            }

            AreaInteresseDTO a = new AreaInteresseDTO(areaInteresse);
            db.AreaInteresse.Remove(areaInteresse);
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

        private bool AreaInteresseExists(int id)
        {
            return db.AreaInteresse.Count(e => e.Codigo == id) > 0;
        }
    }
}