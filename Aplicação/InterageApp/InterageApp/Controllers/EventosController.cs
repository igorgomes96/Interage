using InterageApp.DTO;
using InterageApp.Exceptions;
using InterageApp.Filters;
using InterageApp.Models;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace InterageApp.Controllers
{
    [JwtAuthentication]
    public class EventosController : ApiController
    {
        private readonly IEventosService _eventosService;
        private readonly IFeedbacksService _feedbackService;

        public EventosController(IEventosService eventosService, IFeedbacksService feedbackService)
        {
            _eventosService = eventosService;
            _feedbackService = feedbackService;
        }

        [Route("api/Eventos/Todos")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_eventosService.Listar());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_eventosService.Listar(User.Identity.Name));
            } catch (NaoEncontradoException<Usuario> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_eventosService.Buscar(id));
            }
            catch (NaoEncontradoException<Evento> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [ResponseType(typeof(bool))]
        [Route("api/Eventos/{id}/VerificarInscricao")]
        public IHttpActionResult GetVerificaInscricao(int id)
        {
            try
            {
                return Ok(_eventosService.VerificaInscricao(id, User.Identity.Name));
            }
            catch (NaoEncontradoException<Evento> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Post(EventoDto evento)
        {
            try
            {
                evento.EmailUsuarioPromotor = User.Identity.Name;
                return Ok(_eventosService.CriarNovo(evento));
            }
            catch (ConflitoException<Evento> e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            catch (DbEntityValidationException)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_eventosService.ExcluirEvento(id));
            }
            catch (NaoEncontradoException<Evento> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Eventos/{id}/Atividades")]
        public IHttpActionResult GetAtividades(int id)
        {
            try
            {
                return Ok(_eventosService.Atividades(id));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Eventos/{id}/Feedbacks")]
        public IHttpActionResult GetFeedbacks(int id)
        {
            try
            {
                return Ok(_feedbackService.List(id));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Eventos/{id}/Feedbacks")]
        public IHttpActionResult PostFeedbacks(int id, FeedbackDto feedback)
        {
            if (id != feedback.CodEvento) return Content(HttpStatusCode.BadRequest, "Código de Evento inconsistente!");

            feedback.EmailUsuario = User.Identity.Name;

            try
            {
                return Ok(_feedbackService.SaveFeedback(feedback));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Eventos/{id}/Inscrever")]
        public IHttpActionResult PostInscreverUsuario(int id)
        {
            try
            {
                _eventosService.InscreverParticipante(id, User.Identity.Name);
                return Ok();
            } catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("api/Eventos/{id}/CancelarInscricao")]
        public IHttpActionResult DeleteInscricaoUsuario(int id)
        {
            try
            {
                _eventosService.CancelarInscricao(id, User.Identity.Name);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
