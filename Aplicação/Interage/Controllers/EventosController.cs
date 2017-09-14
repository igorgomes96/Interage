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
    public class EventosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Eventos
        public IEnumerable<EventoDTO> GetEvento()
        {
            return db.Evento.ToList()
                .Select(x => new EventoDTO(x));
        }

        // GET: api/Eventos/5
        [ResponseType(typeof(EventoDTO))]
        public IHttpActionResult GetEvento(int id)
        {
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            return Ok(new EventoDTO(evento));
        }

        // PUT: api/Eventos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvento(int id, Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Codigo)
            {
                return BadRequest();
            }

            db.Entry(evento).State = EntityState.Modified;

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

        // POST: api/Eventos
        [ResponseType(typeof(EventoDTO))]
        public IHttpActionResult PostEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Evento.Add(evento);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return CreatedAtRoute("DefaultApi", new { id = evento.Codigo }, new EventoDTO(evento));
        }

        // DELETE: api/Eventos/5
        [ResponseType(typeof(EventoDTO))]
        public IHttpActionResult DeleteEvento(int id)
        {
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return NotFound();
            }

            EventoDTO e = new EventoDTO(evento);
            db.Evento.Remove(evento);
            db.SaveChanges();

            return Ok(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoExists(int id)
        {
            return db.Evento.Count(e => e.Codigo == id) > 0;
        }
    }
}