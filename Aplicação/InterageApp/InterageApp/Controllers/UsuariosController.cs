using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterageApp.Services.Interfaces;
using InterageApp.DTO;
using Microsoft.AspNetCore.Authorization;

namespace InterageApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosService _usuarioService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuarioService = usuariosService ?? throw new ArgumentNullException(nameof(usuariosService));
        }

        [HttpGet]
        public IEnumerable<UsuarioDTO> Get()
        {
            return _usuarioService.ReadAll();
        }

        [HttpGet("{email}", Name = "Get")]
        public IActionResult Get(string email)
        {
            try
            {
                return Ok(_usuarioService.Read(email));
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioCredenciaisDTO usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return CreatedAtAction(nameof(Get), _usuarioService.Create(usuario));
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody]UsuarioDTO usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _usuarioService.Update(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            try
            {
                return Ok(_usuarioService.Delete(email));
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
