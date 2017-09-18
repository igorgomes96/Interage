using Interage.DTO;
using Interage.Exceptions;
using Interage.Models;
using Interage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Interage.Controllers
{
    public class UsuariosPadroesController : ApiController
    {
        UsuariosPadroesService userService = new UsuariosPadroesService();

        public IEnumerable<UsuarioPadraoDTO> Get()
        {
            return userService.Get();
        }

        [HttpGet]
        [Route("api/UsuariosPadroes/{codUsuario}/{cpf}")]
        [ResponseType(typeof(UsuarioPadraoDTO))]
        public IHttpActionResult Get(int codUsuario, string cpf)
        {
            UsuarioPadraoDTO user = null;
            try { 
                user = userService.Get(codUsuario, cpf);
            } catch (NaoEncontradoException)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [ResponseType(typeof(UsuarioPadraoDTO))]
        public IHttpActionResult Post(UsuarioPadraoDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try { 
                usuario = userService.Post(usuario);
            } catch (ConflitoException)
            {
                return Conflict();
            }

            return Ok(usuario);
            
        }

        [ResponseType(typeof(void))]
        [Route("api/UsuariosPadroes/{codUsuario}/{cpf}")]
        public IHttpActionResult Put(int codUsuario, string cpf, UsuarioPadraoDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                userService.Put(codUsuario, cpf, usuario);
            }
            catch (ParametrosInvalidosException)
            {
                return BadRequest();
            } catch (NaoEncontradoException)
            {
                return NotFound();
            }
            return Ok();

        }

        [ResponseType(typeof(UsuarioPadraoDTO))]
        [Route("api/UsuariosPadroes/{codUsuario}/{cpf}")]
        public IHttpActionResult Delete(int codUsuario, string cpf)
        {
            UsuarioPadraoDTO u = null;
            try { 
                u = userService.Delete(codUsuario, cpf);
            } catch (NaoEncontradoException)
            {
                return NotFound();
            }
            return Ok(u);

        }
    }
}
