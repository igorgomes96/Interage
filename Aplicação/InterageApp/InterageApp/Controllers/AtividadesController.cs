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

    }
}
