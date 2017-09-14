using Interage.DTO;
using Interage.Models;
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
        Contexto db = new Contexto();
        // GET: api/UsuarioPadrao
        public IEnumerable<UsuarioPadraoDTO> Get()
        {
            return db.UsuarioPadrao.ToList()
                .Select(x => new UsuarioPadraoDTO(x));
        }

        [HttpGet]
        [Route("api/UsuariosPadroes/{codUsuario}/{cpf}")]
        [ResponseType(typeof(UsuarioPadraoDTO))]
        public IHttpActionResult Get(int codUsuario, string cpf)
        {
            UsuarioPadrao user = db.UsuarioPadrao.Find(codUsuario, cpf);
            if (user == null) return NotFound();
            return Ok(new UsuarioPadraoDTO(user));
        }

        [ResponseType(typeof(UsuarioPadraoDTO))]
        public IHttpActionResult Post(UsuarioPadraoDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.Usuario.Add(usuario.GetUsuario());

            return Ok();
            
        }

        // PUT: api/UsuarioPadrao/5
        public IHttpActionResult Put(int codUsuario, string cpf, UsuarioPadraoDTO usuario)
        {
        }

        // DELETE: api/UsuarioPadrao/5
        public IHttpActionResult Delete(int codUsuario, string cpf)
        {
        }

        private bool UsuarioPadraoExists(UsuarioPadrao user)
        {
            return db.UsuarioPadrao.Count(x => x.CodUsuario == user.CodUsuario && x.CPF == user.CPF) > 0;
        }
    }
}
