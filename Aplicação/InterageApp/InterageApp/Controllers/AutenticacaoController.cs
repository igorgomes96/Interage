using InterageApp.Exceptions;
using InterageApp.Filters;
using InterageApp.Models;
using InterageApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace InterageApp.Controllers
{
    public class AutenticacaoController : ApiController
    {

        private readonly IAuthService _authService;

        public AutenticacaoController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("api/Autentica")]
        [AllowAnonymous]
        public IHttpActionResult Login(Usuario usuario)
        {
            try
            {
                return Ok(_authService.Login(usuario));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            /*if (usuario == null || usuario.Email == null || usuario.Senha == null) return BadRequest();

            Usuario user = null;

            try { 
                user = db.Usuarios.Find(usuario.CPF);
            } catch (Exception e)
            {
                Trace.WriteLine(e);
            }
            string senhaBD = Encoding.UTF8.GetString(Convert.FromBase64String(user.Senha));
            if (user == null) return BadRequest("Usuário não cadastrado!");

            if (usuario.Senha != senhaBD) return BadRequest("Senha incorreta!");

            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(usuario.CPF + ":" + usuario.Senha));

            //Verifica se já existe a sessão. Se sim, aumenta a data de expiração, caso contrário, cria uma nova sessão
            Sessao s = db.Sessoes.Find(token);
            if (s == null)
                db.Sessoes.Add(new Sessao { Chave = token, LoginUsuario = user.CPF, Inicio = DateTime.Now, Fim = DateTime.Now.AddHours(1.0) });
            else
                s.Fim = DateTime.Now.AddHours(1.0);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            var retorno = new
            {
                Token = token,
                Usuario = user.Nome,
                CPF = user.CPF,
                Perfil = user.Perfil,
                UserObj = new UsuarioDTO(user)
            };

            db.Dispose();
            if (senhaBD == "Admin_" + user.CPF)
                return Content(HttpStatusCode.Accepted, retorno);
            else
                return Ok(retorno);*/
        }
        
        [HttpPost]
        [Route("api/Logout")]
        [AuthenticationFilter]
        public IHttpActionResult Logout()
        {

            return Ok();
            /*Modelo db = new Modelo();
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;
            if (authorization != null)
            {
                if (authorization.Scheme == "Basic")
                {
                    Sessao s = db.Sessoes.Find(authorization.Parameter);
                    if (s != null)
                        db.Sessoes.Remove(s);
                    db.SaveChanges();
                }
            }
            return Ok();*/
        }
    }
}
