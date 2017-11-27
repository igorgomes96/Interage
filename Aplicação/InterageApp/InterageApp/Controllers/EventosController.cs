using InterageApp.DTO;
using InterageApp.Exceptions;
using InterageApp.Models;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterageApp.Controllers
{
    public class EventosController : ApiController
    {
        private readonly IEventosService _eventosService;

        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
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

        public IHttpActionResult Post(EventoDto evento)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            try
            {
                return Ok(_eventosService.CriarNovo(evento));
            }
            catch (ConflitoException<Evento> e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
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

    }
}
