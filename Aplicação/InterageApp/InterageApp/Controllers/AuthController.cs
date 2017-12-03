using InterageApp.Auth;
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
    public class AuthController : ApiController
    {
        private readonly IValidateUserService _validateUser;
        private readonly IUsuariosService _usuariosService;

        public AuthController(IValidateUserService validateUser,
            IUsuariosService usuariosService)
        {
            _validateUser = validateUser;
            _usuariosService = usuariosService;
        }

        [HttpPost]
        public IHttpActionResult Authenticate(CredenciaisDto credenciais)
        {
            try
            {
                if (_validateUser.CheckUser(credenciais))
                {
                    UsuarioDto usuario = _usuariosService.BuscaUsuario(credenciais.Email);
                    usuario.Token = JwtManager.GenerateToken(credenciais.Email, 120);
                    return Ok(usuario);
                }
                return Content(HttpStatusCode.BadRequest, "Credenciais inválidas");
            } catch (NaoEncontradoException<Usuario> e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("api/Auth/RecuperarSenha")]
        public IHttpActionResult RecuperarSenha(CredenciaisDto credenciais)
        {
            try
            {
                _validateUser.RecuperarSenha(credenciais.Email);
                return Ok();
            } catch(Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }
        }
    }
}
