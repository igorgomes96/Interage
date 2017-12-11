using InterageApp.DTO;
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
    public class InteracoesController : ApiController
    {
        private readonly IInteracaoService _interacaoService;

        public InteracoesController(IInteracaoService interacaoService)
        {
            _interacaoService = interacaoService;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_interacaoService.List(id));
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Post(InteracaoDto interacao)
        {
            try
            {
                interacao.EmailUsuario = User.Identity.Name;
                return Ok(_interacaoService.EnviarMensagem(interacao));
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
