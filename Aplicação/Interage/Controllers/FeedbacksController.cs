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
    public class FeedbacksController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Feedbacks
        public IEnumerable<FeedbackDTO> GetFeedback()
        {
            return db.Feedback.ToList().Select(x => new FeedbackDTO(x));
        }

        // GET: api/Feedbacks/5
        [Route("api/Feedbacks/{codEvento}/{codUsuario}")]
        [ResponseType(typeof(FeedbackDTO))]
        public IHttpActionResult GetFeedback(int codEvento, int codUsuario)
        {
            Feedback feedback = db.Feedback.Find(codEvento, codUsuario);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(new FeedbackDTO(feedback));
        }

        // PUT: api/Feedbacks/5
        [Route("api/Feedbacks/{codEvento}/{codUsuario}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedback(int codEvento, int codUsuario, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (codEvento != feedback.CodEvento && codUsuario != feedback.CodUsuario)
            {
                return BadRequest();
            }

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                if (!FeedbackExists(codEvento, codUsuario))
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError(e);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Feedbacks
        [ResponseType(typeof(FeedbackDTO))]
        public IHttpActionResult PostFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feedback.Add(feedback);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                if (FeedbackExists(feedback.CodEvento, feedback.CodUsuario))
                {
                    return Conflict();
                }
                else
                {
                    return InternalServerError(e);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = feedback.CodEvento }, new FeedbackDTO(feedback));
        }

        // DELETE: api/Feedbacks/5
        [Route("api/Feedbacks/{codEvento}/{codUsuario}")]
        [ResponseType(typeof(FeedbackDTO))]
        public IHttpActionResult DeleteFeedback(int codEvento, int codUsuario)
        {
            Feedback feedback = db.Feedback.Find(codEvento, codUsuario);
            if (feedback == null)
                return NotFound();

            FeedbackDTO f = new FeedbackDTO(feedback);
            db.Feedback.Remove(feedback);
            db.SaveChanges();

            return Ok(f);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(int codEvento, int codUsuario)
        {
            return db.Feedback.Count(e => e.CodEvento == codEvento && e.CodUsuario == codUsuario) > 0;
        }
    }
}