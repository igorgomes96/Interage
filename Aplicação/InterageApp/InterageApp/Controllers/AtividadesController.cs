using InterageApp.DTO;
using InterageApp.Exceptions;
using InterageApp.Filters;
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
    [JwtAuthentication]
    public class AtividadesController : ApiController
    {
        private readonly IAtividadesService _atividadesService;

        public AtividadesController(IAtividadesService atividadesService)
        {
            _atividadesService = atividadesService;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_atividadesService.Buscar(id));
            } catch (NaoEncontradoException<Atividade> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Post(AtividadeDto atividade)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            try
            {
                return Ok(_atividadesService.CriarNova(atividade));
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
                return Ok(_atividadesService.ExcluirAtividade(id));
            }
            catch (NaoEncontradoException<Atividade> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Atividades/{id}/InscreverParticipante/{emailUsuario}")]
        public IHttpActionResult PostInscreverParticipante(int id, string emailUsuario)
        {
            try
            {
                _atividadesService.InscreverParticipante(id, emailUsuario);
                return Ok();
            }
            catch (NaoEncontradoException<Atividade> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (NaoEncontradoException<Usuario> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("api/Atividades/{id}/CancelarInscricao/{emailUsuario}")]
        public IHttpActionResult DeleteCancelarInscricao(int id, string emailUsuario)
        {
            try
            {
                _atividadesService.CancelarInscricao(id, emailUsuario);
                return Ok();
            }
            catch (NaoEncontradoException<Atividade> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (NaoEncontradoException<Usuario> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
