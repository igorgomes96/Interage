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
    public class UsuariosController : ApiController
    {

        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }


        public IHttpActionResult PostCadastrar(UsuarioCredenciaisDto usuario)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState);

            try
            {
                return Ok(_usuariosService.Cadastrar(usuario));
            } catch (ConflitoException<Usuario> e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult DeleteCadastro(string id)
        {
            try
            {
                return Ok(_usuariosService.ExcluirCadastro(id));
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
